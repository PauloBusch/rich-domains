using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Payment.Tests
{
    [TestClass]
    public class StudantTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription();
            var staudant = new Student(
                firstName: "Nome",
                lastName: "Sobrenome",
                document: "32165498721",
                email: "paulo@teste.com"
            );
            staudant.AddSubscription(subscription);
        }
    }
}
