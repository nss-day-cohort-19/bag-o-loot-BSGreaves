using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class DeliveryManagerShould 
    {
        private readonly DeliveryManager _deliveryManager;

        public DeliveryManagerShould()
        {
            _deliveryManager = new DeliveryManager();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("5")]
        [InlineData("17")]
        public void ConfirmDelivery (int childid) {
            var result = _deliveryManager.ConfirmDelivery(childid);
            Assert.True(result);
        }

        [Fact]
        public void ListConfirmedDeliveries () {
            var result = _deliveryManager.ListConfirmedDeliveries();
            Assert.IsType<List<string>>(result);
        }
    }
}
