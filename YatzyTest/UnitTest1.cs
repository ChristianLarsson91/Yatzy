using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace YatzyTest
{
    [TestClass]
    public class YatzyGame
    {

        [TestMethod]
        public void TestMethodScore()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(2,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(4,"") },
            };
            var Expected = 6;
            var result = Yatzy.YatzyGame.CheckNumberOfPoints(rolledDice, 3);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckNumberOfPoints()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(3,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(4,"") },
            };
            var Expected = 9;
            var result = Yatzy.YatzyGame.CheckNumberOfPoints(rolledDice,3);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckFullHouse()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(1,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(2,"") },
            };
            var Expected = 7;
            var result = Yatzy.YatzyGame.CheckFullHouse(rolledDice);
            Assert.AreEqual(Expected, result);
        }
    }
}
