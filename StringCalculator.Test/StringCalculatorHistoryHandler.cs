using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using StringCalculator.Persistance;


namespace HisoryControllerHandler.Test
{
    internal class HistoryHandlerShould
    {
        private Save storer;
        private StringCalculatorHistoryHandler handler;

        [SetUp]
        public void Setup()
        {
            storer = Substitute.For<Save>();
            handler = new StringCalculatorHistoryHandler(storer);
        }


        [Test]
        public void return_expected_string_calculator_result()
        {
            var res = handler.HandleRequest("1,2,4");

            res.Should().Be(7);
        }

        [Test]
        public void write_given_data_on_correct_format()
        {

            handler.HandleRequest("1,2,3");

            storer.Received(1).StoreData(DateTime.Now + " " + "1,2,3 6");
        }
    }
}
