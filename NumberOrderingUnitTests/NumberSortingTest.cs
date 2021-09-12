using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Controllers;
using NumberOrdering.Data;
using System;
using Xunit;
using NumberOrderingUnitTests;
using NumberOrdering.Models;
using System.Collections.Generic;
using NumberOrdering.NumberData;

namespace NumberOrderingUnitTests
{
    public class NumberSortingTest
    {
        public static Numbers num = new Numbers()
        {
            arList = new List<int> { 43, 21, 36 }
        };

        NumbersController _controller;
        IDataService _service;

        public NumberSortingTest()
        {
            _service = new IDataServiceFake();
            _controller = new NumbersController(_service);
        }
        [Fact]
        public void Get_Sorted_Number_Test()
        {
            var okResult = _controller.GetTextFile();
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Post_Sorted_Number_Test()
        {
            var createdResponse = _controller.PostNumbers(num) as CreatedAtActionResult;
            var ds = _service.PostArrayData(num);
            Assert.Equal(21, num.arList[0]);
            Assert.Equal(36, num.arList[1]);
            Assert.Equal(43, num.arList[2]);
        }
    }
}
