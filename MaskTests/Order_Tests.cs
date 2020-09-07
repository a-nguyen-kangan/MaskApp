using System;
using Xunit;
using MaskApi.models;

namespace MaskTests
{
    public class OrderTest {
        Mask newMask1 = new Mask("m-9999", 1, "White", true, false, "Flowers", true, 10.00);
        Mask newMask2 = new Mask("m-8888", 3, "Black", false, true, "RaceCars", true, 3.50);

        [Fact]
        public void SetPriceTest() {
            Order order1 = new Order(newMask1, 3);
            Order order2 = new Order(newMask2, 10);
            
            Assert.Equal(30.00, order1.Price);
            Assert.Equal(35.00, order2.Price);
        }

        [Fact]
        public void GenerateOrderNoTest() {
            Order order1 = new Order(newMask1, 3);
            Order order2 = new Order(newMask2, 10);

            int num1 = order1.GenerateOrderNo();
            int num2 = order1.GenerateOrderNo();
            int num3 = order2.GenerateOrderNo();
            int num4 = order2.GenerateOrderNo();

            if(num1 == num2 || num1 == num3 || num1 == num4 || num2 == num3 || num2 == num4 || num3 == num4) {
                Assert.True(false);
            }

            if((num1 >= 1000 && num1 <= 9999) && (num2 >= 1000 && num2 <= 9999) && 
                                        (num3 >= 1000 && num3 <= 9999) && (num4 >= 1000 && num4 <= 9999)) {
                Assert.True(true);
            } else {
                Assert.True(false);
            }


        }
    }
}