using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Contract;

namespace FCI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly ISupplier _supplier;
        public SupplierController(ISupplier supplier)
        {
            this._supplier = supplier;

        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var response = await this._supplier.GetAllSuppliers();
            return Ok(response);
            //return Ok(await Mediator.Send(new GetAllSuppliers()));

            // return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetSingleRecord(long id)
        {
            return Ok(await this._supplier.GetSingleSupplier(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            return Ok(await this._supplier.AddSupplier(supplier));

        }

        //[HttpPost("add")]
        //public IActionResult AddUser(User user)
        //{
        //    return Ok(this._user.AddUserRepo(user));

        //}


        [HttpDelete]
        public async Task<IActionResult> RemoveSupplier(long id)
        {
            return Ok(await this._supplier.RemoveSupplier(id));

        }


        [HttpPut("edit")]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier)
        {
            return Ok(await this._supplier.UpdateSupplier(supplier));

        }
    }
}
