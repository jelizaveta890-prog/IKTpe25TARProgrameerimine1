<<<<<<< HEAD
﻿﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel.CourseVM;
=======
﻿using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using University.Data;
using University.Models;
using University.ViewModel.CoursesVM;
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce

namespace University.Controllers
{
    public class CourseController : Controller
    {
<<<<<<< HEAD
        private readonly UniversityContext _context;
        public CourseController
            (
                UniversityContext context
=======
        //on vaja kutsuda välja  University constructor 

        private readonly UniversityContext _context;

        public CourseController

            (
                 UniversityContext context
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var course = _context.Courses
<<<<<<< HEAD
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
=======
                .Include(c => c.Departments)
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                });

            return View(course);
<<<<<<< HEAD
=======

>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
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
<<<<<<< HEAD
=======

>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
<<<<<<< HEAD
            PopulateDepartmentDropDownList();
            return View();
=======

            PopulateDepartmentDropDownList();
            return View();

>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create(CourseCreateViewModel vm)
=======
        public async Task<IActionResult> Creat(CourseCreateViewModel vm)
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
        {

            var course = new Course
            {
                CourseId = vm.CourseId,
                Title = vm.Title,
                Credits = vm.Credits,
<<<<<<< HEAD
                DepartmentId = vm.DepartmentId,
=======
                Departments = new Department
                {
                    Name = vm.Department.Name
                }
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
            };

            _context.Add(course);
            await _context.SaveChangesAsync();

<<<<<<< HEAD
            PopulateDepartmentDropDownList(course.DepartmentId);
            return RedirectToAction(nameof(Index));
=======

            PopulateDepartmentDropDownList(course.DepartmentId);
            return RedirectToAction(nameof(Index));

>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
        }

        public async Task<IActionResult> Details(int? id)
        {
<<<<<<< HEAD
            if (id == null)
            {
                return NotFound();
            }
=======
>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce

            var course = await _context.Courses
                .Include(c => c.Departments)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
<<<<<<< HEAD
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _context.Departments
                .OrderBy(d => d.Name)
                .GroupBy(d => d.Name)
                .Select(g => g.First());

            ViewBag.DepartmentId = new SelectList(departmentsQuery
                .AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }
    }
}
=======
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName =  c.Departments.Name 
                    }
                })
                .FirstOrDefaultAsync();
            
                if (course == null)
                {
                    return NotFound();
                }

           
                return View(course);
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

>>>>>>> 17a732c7a52a28fa619ec64e0cfb50b287d635ce
