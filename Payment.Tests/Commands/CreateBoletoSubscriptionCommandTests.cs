using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            Assert.IsFalse(command.Valid);
        }
    }
}
