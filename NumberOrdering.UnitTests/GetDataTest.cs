using NumberOrdering.Models;
using NUnit.Framework;

namespace NumberOrdering.UnitTests
{
    public class GetDataTest
    {
        private Numbers num = new Numbers()
        {
            arList = new System.Collections.Generic.List<int> { 5, 3, 4 }
        };
    
        [SetUp]
        public void Setup()
        {
             
        }
    

        [Test]
        public void Tes1()
        {
             
            Assert.Pass();
        }
    }
}