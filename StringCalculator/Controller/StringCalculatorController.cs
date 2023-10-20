using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StringCalculator.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class StringCalculatorController : ControllerBase
    {
        StringCalculatorClass calc = new StringCalculatorClass();

        // GET api/<StringCalculatorController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return calc.add(id).ToString(); ;
        }

    }
}

