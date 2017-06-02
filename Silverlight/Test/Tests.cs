using NUnit.Framework;
using Omu.ValueInjecter.Silverlight;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var p = new Product() { ModelName = "das name", Description = "bla", ModelNumber = "über", UnitCost = 1231 };
            var vm = new ProductViewModel();
            vm.InjectFrom(p);
            Assert.AreEqual(p.ModelName, vm.ModelName);
            Assert.AreEqual(p.Description, vm.Description);
            Assert.AreEqual(p.ModelNumber, vm.ModelNumber);
            Assert.AreEqual(p.UnitCost, vm.UnitCost);
        }
    }
}
