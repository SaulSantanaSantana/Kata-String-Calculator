using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using StringCalculator.Persistance;
using System;
using System.IO;
using System.Linq;

namespace StringCalculator.Test
{
    public class HistoryControllerShould
    {

        private Save historyStorer;
        private TimePicker timePicker;

        [SetUp]
        public void Setup()
        {
            timePicker = Substitute.For<TimePicker>();
            historyStorer = new HistoryStorer("historyTest.txt", timePicker);
        }

        [Test]
        public void write_data_on_get_request()
        {
            var expectedDate = DateTime.Now;
            timePicker.GetDate().Returns(expectedDate);
            historyStorer.StoreData("TestsString","TestOutout");
            
            var result = File.ReadLines("historyTest.txt").Last();

            result.Should().Be(expectedDate + " TestsString TestOutout");

        }
    } 
}
