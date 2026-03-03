using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CalculatorApp.Test
{
    [TestFixture]
    internal class CalculatorTest
    {
        private CalculatorApp.Calculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }
        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int a = 5, b = 3;
            int result=calc.Add(a, b);
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Substract_TwoNumbers_ReturnDifference()
        {
            int a = 10, b = 4;
            int result=calc.Substract(a, b);
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void Multiply_TwoNumbers_ReturnProduct()
        {
            int a = 10, b = 4;
            int result = calc.Multiple(a, b);
            Assert.That(result, Is.EqualTo(40));
        }
        [Test]
        public void Divide_ByZero_ThrowException()
        {
            int a = 10;
            int b= 0;
            Assert.Throws<DivideByZeroException>(() => calc.Divide(a, b));

        }
        [Test]
        public void Divide_TwoNumbers_ReturnDifference()
        {
            int a = 20, b = 4;
            double result = calc.Divide(a, b);
            Assert.That(result, Is.EqualTo(5));
        }


    }
}
