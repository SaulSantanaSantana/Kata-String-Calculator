using FluentAssertions;
using NUnit.Framework;
using StringCalculator.Model;
using System;

namespace StringCalculator.Test
{
    public class StringCalculatorShould{

        [Test]
        public void return_0_on_empty_string(){

            var res = StringCalculatorClass.add("");

            res.Should().Be(0);
        }

        [Test]
        public void return_same_number_on_one_number(){

            var res = StringCalculatorClass.add("1");
            
            res.Should().Be(1);
        }

        [Test]
        public void return_sum_on_two_values(){

            var res = StringCalculatorClass.add("1,2");

            res.Should().Be(3);
        }

        [Test]
        public void return_sum_on_many_values(){

            var res = StringCalculatorClass.add("1,2,3,4,5");

            res.Should().Be(15);
        }

        [Test]
        public void ignore_new_Lines(){

            var res = StringCalculatorClass.add("1\n2\n3\n4\n5");

            res.Should().Be(15);
        }

        [Test]
        public void ignore_new_lines_and_see_commas(){

            var res = StringCalculatorClass.add("1\n2\n3,4,5");

            res.Should().Be(15);
        }

        [Test]
        public void return_sum_changing_delimiter(){

            var res = StringCalculatorClass.add("//;1\n2\n3;4;5");
            
            res.Should().Be(15);
        }

        [Test]
        public void throw_negative_number_exception(){

            var action = () => StringCalculatorClass.add("-1,-2,-3");

            action.Should().Throw<NegativesNotAlloweException>().WithMessage("Negatives not allowed: -1 -2 -3");
        }

        [Test]
        public void ignore_numbres_over_one_thousand(){

            var res = StringCalculatorClass.add("100000,2");

            res.Should().Be(2);
        }
    }
}