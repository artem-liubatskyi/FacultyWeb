using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faculty.Data;

namespace Test2.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _subjectService.GetAll());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
    }
}
