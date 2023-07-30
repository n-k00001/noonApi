using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Contract;
using noon.Application.Services.ProductBrandServices;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using noon.Infrastructure.Repositorys;
using System.Data;

namespace noonDashboard.MVC.Controllers
{
    [Authorize(Roles = "admin ")]
    public class ProductBrandController : Controller
    {
        private readonly IProductBrandServices brandServices;

        public ProductBrandController(IProductBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }
        public async Task <IActionResult> Index()
        {
            var data = brandServices.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductBrandDTO brandDto)
        {
            if (ModelState.IsValid)
            {
                brandServices.Create(brandDto);
                return RedirectToAction("index");
            }
            return View(brandDto);
        }

        public async Task< IActionResult> Edit(int id)
        {
            var data = await brandServices.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProductBrandDTO brandDTO)
        {
            if (ModelState.IsValid)
            {
                brandServices.Update(brandDTO);
                return RedirectToAction("index");
            }
            return View(brandDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await brandServices.GetById(id);
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            brandServices.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
