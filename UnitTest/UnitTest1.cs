using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YatzyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Yatzy.YatzyGame.CheckFullHouse();
            }
        }
    }
}
