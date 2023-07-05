using BackEnd.Models;
using DAL.Interfaces;
using DAL.Implementations;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductModel Convertir(Product product)
        {
            return new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };

        }

        Product Convertir(ProductModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };

        }


        IProductDAL productDAL;


        public ProductController()
        {
            productDAL = new ProductDALImpl();
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {

            IEnumerable<Product> products = await productDAL.GetAll();

            List<ProductModel> lista = new List<ProductModel>();

            foreach (var item in products)
            {
                lista.Add(Convertir(item));
            }

            return new JsonResult(lista);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Product product = await productDAL.Get(id);

            return new JsonResult(product);

        }

        // POST api/<ProductController>
        [HttpPost]
        public JsonResult Post([FromBody] ProductModel productModel)
        {
            Product product = Convertir(productModel);

            productDAL.Add(product);

            return new JsonResult(product);

        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public JsonResult Put( [FromBody] ProductModel productModel)
        {
            Product product = Convertir(productModel);

            productDAL.Update(product);

            return new JsonResult(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Product product = new Product
            {
                ProductId = id
            };
            productDAL.Remove(product);

            return new JsonResult(product);
        }
    }
}
