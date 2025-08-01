
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSKNDotNetTrainingBatch2.WebApi.Database.AppDbContextModels;

namespace MSKNDotNetBatch2.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly AppDbContext _db;
		public ProductController()
		{
			_db = new AppDbContext();
		}
		[HttpGet]
		public IActionResult GetProducts()
		{
			var lst = _db.TblProducts.Where(x => x.DeleteFlag == false).ToList(); // pagination
			return Ok(lst);
		}

		[HttpPost]
		public IActionResult CreateProduct(TblProduct product)
		{
			_db.TblProducts.Add(product);
			_db.SaveChanges();
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpsertProduct(int id, TblProduct product)
		{
			var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
			if (item is null)
			{
				_db.TblProducts.Add(product);
				_db.SaveChanges();
			}
			else
			{
				item.ProductName = product.ProductName;
				item.ProductCode = product.ProductCode;
				item.Price = product.Price;
				_db.SaveChanges();
			}
			return Ok();
		}

		[HttpPatch("{id}")]
		public IActionResult UpdateProduct(int id, TblProduct product)
		{
			var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
			if (item is null)
			{
				return NotFound();
			}

			item.ProductName = product.ProductName;
			item.ProductCode = product.ProductCode;
			item.Price = product.Price;
			_db.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
			if (item is null)
			{
				return NotFound();
			}

			item.DeleteFlag = true;
			_db.SaveChanges();
			return Ok();
		}
	}
}
