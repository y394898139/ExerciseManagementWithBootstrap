using CompWithBoo.Models;
using CompWithBoo.Repositories;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CompWithBoo.Controllers
{
    public class ExerciseController : Controller
    {
        private IExerciseRepository<Exercise, string> _repository;


        public const int pageSize = 5;

        public ExerciseController()
        {
            _repository = new ExerciseRepository(new ExerciseContext());
        }

        public ExerciseController(IExerciseRepository<Exercise, string> repo)
        {
            _repository = repo;
        }
        // GET: Exercise
        public ActionResult Index()
        {
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = _repository.Get().Count();
            return View();
        }

        public ActionResult Exercise_Read()
        {
            var data = _repository.Get().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Create(Exercise exercise)
        {
            _repository.Add(exercise);
            return Json("success", JsonRequestBehavior.AllowGet);
        }


    }
}