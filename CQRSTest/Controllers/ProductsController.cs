using CQRSTest.CQRS.Command;
using CQRSTest.CQRS.Query;
using CQRSTest.Domain;
using CQRSTest.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;


        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }
     

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(new{ product, date=  DateTime.UtcNow.AddHours(1)
        });
        }


        [HttpGet(Name = "GetAllsProduct")]
        public async Task<ActionResult> GetAllsProduct()
        {
            var product = await _mediator.Send(new  GetProductsQuery());
            return Ok(new
            {
                product,
                date = DateTime.UtcNow.AddHours(1)
            });
        }
    }
}
