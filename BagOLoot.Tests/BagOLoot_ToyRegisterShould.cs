using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ToyRegisterShould
    {
        private readonly ToyRegister _toyRegister;

        public ToyRegisterShould()
        {
            _toyRegister = new ToyRegister();
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        public void AddToy (int childid, int toyid)
        {
           var result = _toyRegister.AddToy(childid, toyid);
           Assert.True(result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        public void RevokeToy (int childid, int toyid)
        {
           var result = _toyRegister.RevokeToy(childid, toyid);
           Assert.True(result);
        }

        [Fact]
        public void GetToyList ()
        {
            var result = _toyRegister.GetToyList();
            Assert.IsType<List<string>>(result);
        }
    }
}
