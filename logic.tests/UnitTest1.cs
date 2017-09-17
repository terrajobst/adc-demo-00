using System;
using Xunit;

namespace logic.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var name = "Immo";
            var message = logic.HelloWorld.GetMessage(name);

            Assert.Equal(message, "Hello Immo!");
        }
    }
}
