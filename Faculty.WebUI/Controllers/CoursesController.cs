using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Faculty.Data;
using Faculty.Data.Models;

namespace Test2.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService) => _courseService = courseService;
        
        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAll());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetById((int)id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
