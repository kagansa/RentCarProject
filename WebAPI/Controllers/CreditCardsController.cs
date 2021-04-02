using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private ICreditCardService _cardService;
        private ICustomerService _customerService;

        public CreditCardsController(ICreditCardService paymentService,ICustomerService customerService)
        {
            _cardService = paymentService;
            _customerService = customerService;
        }

        [HttpPost("payment")]
        public IActionResult Payment(CreditCard card)
        {
            Thread.Sleep(2000);
            var result = _cardService.Payment(card);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard card)
        {
            var userId = _customerService.GetById(card.UserId);
            card.UserId = userId.Data.UserId;
            var result = _cardService.Add(card);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _cardService.GetByUserId(userId);
            return Ok(result.Data);
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int customerId)
        {
            var userId = _customerService.GetById(customerId);
            if (userId.Data == null)
            {
                return BadRequest();
            }
            var result = _cardService.GetAll(userId.Data.UserId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}