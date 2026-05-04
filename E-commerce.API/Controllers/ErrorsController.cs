using E_commerce.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    public class ErrorsController : BaseApiController
    {
        public StoreContext _storeContext { get; }

        public ErrorsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        [HttpGet("notfound")] //Get : api/Errors/NotFound
        public ActionResult GetNotFound() 
        {
            var product = _storeContext.products.Find(100);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpGet("badrequest")] //Get : api/Errors/BadRequest
        public ActionResult GetBadRequest() 
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")] //Get : api/Errors/five
        public ActionResult GetBadRequestValidationError(int id) 
        {
            return Ok();
        }

        //[HttpGet("{id}")] //Get :/api/Errors/1
        //public ActionResult ValidationError(int id) 
        //{
        //    return Ok();
        //}


        [HttpGet("servererror")] //Get :/api/Errors/ServerError
        public ActionResult GetServerError()
        {
            var product = _storeContext.products.Find(100);
            var returnproduct = product.ToString();
            return Ok(returnproduct);
        }
    }
}
