using FluentAssertions;
using NUnit.Framework;
using StringCalculator.Persistance;
using System;
using System.IO;
using System.Linq;

namespace StringCalculator.Test
{
    public class HistoryControllerShould
    {

        private HistoryStorer historyStorer;

        [SetUp]
        public void Setup()
        {
            historyStorer = new HistoryStorer("historyTest.txt");
        }

        [Test]
        public void write_data_on_get_request()
        {
            var path = "historyTest.txt";
            historyStorer.StoreData("TestsString");

            var result = File.ReadLines(path).First();

            result.Should().Be("TestsString");
            
        }
    } 
}
