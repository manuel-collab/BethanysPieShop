using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepostory;

        public PieController(IPieRepository pieRepository, 
                             ICategoryRepository categoryRepostory)
        {
            _pieRepository = pieRepository;
            _categoryRepostory = categoryRepostory;
        }

        public IActionResult NewPie()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult PostNewPie (PieViewModel pieViewModel)
        {
            bool result = _pieRepository.CreateNewPie(pieViewModel);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult List()
        {
            PieListViewModel piesListViewModel = new PieListViewModel
                (_pieRepository.AllPies, "All Pies");

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
