using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould
    {
        private readonly ChildRegister _childRegister;

        public ChildRegisterShould()
        {
            _childRegister = new ChildRegister();
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void AddChild(string childName)
        {
            var result = _childRegister.AddChild(childName);
            Assert.True(result);
        }

        [Fact]
        public void GetChildList()
        {
            var result = _childRegister.GetChildList();
            Assert.IsType<List<(string, int)>>(result);
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void GetChild(string childName)
        {
            var result = _childRegister.GetChild(childName);
            Assert.IsType<int>(result);
        }
    }
}
