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

        private void StoreRequest(string id,string res){
            var dataToStore = DateTime.Now + " " + id + " " +res;
            HistoryController.StoreDataInHistory(dataToStore);
        }

        // GET api/<StringCalculatorController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string res = StringCalculatorClass.add(id).ToString();
            StoreRequest(id, res);
            return res;
        }

        

    }
}

