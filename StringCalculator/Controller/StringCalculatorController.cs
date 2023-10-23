using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StringCalculator.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class StringCalculatorController : ControllerBase
    {

        private ArrayList requests = new ArrayList();

        private StringCalculatorClass calc = new StringCalculatorClass();

        private void storeRequest(string id,string res){
            requests.Add((id, res).ToString());
        }

        // GET api/<StringCalculatorController>/
        [HttpGet]
        public string Get()
        {    
            return requests.ToString();
        }

        // GET api/<StringCalculatorController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string res = calc.add(id).ToString();
            storeRequest(id, res);
            return res;
        }

        

    }
}

