using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Model;
using StringCalculator.Persistance;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StringCalculator.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class StringCalculatorController : ControllerBase
    {
        private StringCalculatorHistoryHandler handler = new StringCalculatorHistoryHandler(new HistoryStorer("history.txt", new HistoryTimePicker()));

        // GET api/<StringCalculatorController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {

            return handler.HandleRequest(id).ToString();
        }

        

    }
}

