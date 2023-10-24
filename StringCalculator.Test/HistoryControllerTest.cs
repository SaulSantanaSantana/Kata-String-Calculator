using FluentAssertions;
using NUnit.Framework;
using StringCalculator.Persistance;
using System;

namespace StringCalculator.Test
{
    public class HistoryControllerShould
    {

        [Test]
        public void write_data_on_get_request()
        {
            HistoryController.StoreDataInHistory("TestsString");

            var result = HistoryController.GetLastEntry();

            result.Should().Be("TestsString");
            
        }
    } 
}
