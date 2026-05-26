using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Data;
using University.Models;

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
            var result = await _context.Courses
                  .Include(c => c.DepartmentId)
                  .AsNoTracking()
                  .ToListAsync();

            return View(result);
        }

    }
}

