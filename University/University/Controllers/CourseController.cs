using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using University.Data;
using University.Models;
using University.ViewModel.CoursesVM;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        //on vaja kutsuda välja  University constructor 

        private readonly UniversityContext _context;

        public CourseController

            (
                 UniversityContext context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var course = _context.Courses
                .Include(c => c.Departments)
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                });

            return View(course);

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseUpdateViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments != null ? c.Departments.Name : null
                    }
                })
                .FirstOrDefaultAsync();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Credits = vm.Credits,
                    Departments = new Department
                    {
                        Name = vm.Department.DepartmentName
                    }
                };

                _context.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {

            PopulateDepartmentDropDownList();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat(CourseCreateViewModel vm)
        {

            var course = new Course
            {
                CourseId = vm.CourseId,
                Title = vm.Title,
                Credits = vm.Credits,
                Departments = new Department
                {
                    Name = vm.Department.Name
                }
            };

            _context.Add(course);
            await _context.SaveChangesAsync();


            PopulateDepartmentDropDownList(course.DepartmentId);
            return RedirectToAction(nameof(Index));

        }

        private void PopulateDepartmentDropDownList(object selectDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentId = new SelectList(departmentsQuery
                .AsNoTracking(), "DepartmentId", "Name", departmentsQuery);

        }
    }
}

