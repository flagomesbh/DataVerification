﻿using DataValidator.Date;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Tests
{
    [TestFixture]
    public class DateUnitTests
    {
        public ICheckDate checkDate { get; set; }

        [OneTimeSetUp]
        public void Config()
        {
            checkDate = new CheckDate();
        }

        [Test]
        [TestCase("O natal esse ano acontece no dia 25/12/2018", "MM/dd/yyyy", true, false, "12/25/2018", true)]
        [TestCase("The D-Day happened on 6/6/1944", "dd/MM/yyyy", false, false, "06/06/1944", true)]
        [TestCase("Albert Einstein was born on 14/03/1879", "dd/MM/yyyy", false, false, "14/03/1879", true)]
        [TestCase("Só vou fazer isso dia 31/02/2019", "dd/MM/yyyy", false, false, "01/01/0001", false)]
        public void TestCheckDate(string text, string format, bool isHolyday, bool isWeekend, string expectedOutput, bool isValid)
        {
            // Arrange

            // Act
            var result = checkDate.ValidateAndFormatDate(text, format);

            // Arrange
            result.IsHoliday.ShouldBe(isHolyday);
            result.IsWeekend.ShouldBe(isWeekend);
            result.Value.ShouldBe(expectedOutput);
            result.IsValid.ShouldBe(isValid);
        }
    }
}