using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Context;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IRepository<ProductModel> _repository;
        public ProductsController(IRepository<ProductModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.Id = GenerateProductId();

            await _repository.AddAsync(product);
            await _repository.SaveAsync();

            BackgroundJob.Enqueue<EmailJobService>(
            job => job.SendProductCreatedEmail(
                "dipika.borwar@autodesk.com",
                "Product is created " + product.Name + product.Price));

            return RedirectToAction("Index");
        }

        private string GenerateProductId()
        {
            return "PRD" + Guid.NewGuid()
                .ToString("N")
                .Substring(0, 6)
                .ToUpper();
        }

        public async Task<IActionResult> Index()
        {
            var products =
                await _repository.GetAllAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(product);
            await _repository.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
