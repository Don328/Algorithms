using NumberGenerator.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmTests.NumberGeneratorTests
{
    public class ListReader_Tests
    {
        [Fact]
        public void SortList_Test()
        {
            var unsorted = new List<int>
            { 87, 37, 19, 41, 53, 9, 3, 72, 18, 29};
            var sorted = new List<int>
            { 3, 9, 18, 19, 29, 37, 41, 53, 72, 87};

            var result = ListReader.SortList(unsorted);
            Assert.NotEqual(result, unsorted);
            Assert.Equal(result, sorted);
        }
    }
}
