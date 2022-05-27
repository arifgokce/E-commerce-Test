using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiburada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperation _productOperation;
        private readonly IIncreaseTimeOperation _increaseTimeOperation;
        public ProductController(IProductOperation productOperation,
             IIncreaseTimeOperation increaseTimeOperation)
        {
            this._productOperation = productOperation;
            this._increaseTimeOperation = increaseTimeOperation;
        }

        [HttpPost("Get-Product-Info")]
        public IActionResult GetProduct(string ProductCode)
        {
            Response<Product> result = _productOperation.GetProductByCode(ProductCode);
            if (result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Create-Product")]
        public IActionResult CreateProduct(CreateProductModel createProductModel)
        {
            Response<string> result = _productOperation.CreateProduct(createProductModel);
            if (result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 

        [HttpPost("increase-time")]
        public IActionResult IncreaseTime(int time)
        {
            return Ok(_increaseTimeOperation.UpdateIncrease(time));
        }
    }
}
