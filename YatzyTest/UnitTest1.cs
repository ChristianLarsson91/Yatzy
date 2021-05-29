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
            var result = Yatzy.Scoring.CheckNumberOfPoints(rolledDice, 2);
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
            var result = Yatzy.Scoring.CheckNumberOfPoints(rolledDice,3);
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
            var result = Yatzy.Scoring.CheckFullHouse(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckOnePair()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(3,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 6;
            var result = Yatzy.Scoring.CheckOnePair(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckTwoPair()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(3,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(5,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 16;
            var result = Yatzy.Scoring.CheckTwoPair(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodChecThreeOfAKind()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(2,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 6;
            var result = Yatzy.Scoring.CheckThreeOfAKind(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodChecFourOfAKind()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(5,"") },
                {Tuple.Create(5,"") },
                {Tuple.Create(5,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 20;
            var result = Yatzy.Scoring.CheckFourOfAKind(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckSmallStright()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(4,"") },
                {Tuple.Create(1,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 15;
            var result = Yatzy.Scoring.CheckSmallStright(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckLargeStright()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(4,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 20;
            var result = Yatzy.Scoring.CheckLargeStright(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckChance()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(3,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(3,"") },
                {Tuple.Create(2,"") },
                {Tuple.Create(5,"") },
            };
            var Expected = 15;
            var result = Yatzy.Scoring.CheckChance(rolledDice);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethodCheckYatzy()
        {
            List<Tuple<int, string>> rolledDice = new List<Tuple<int, string>>()
            {
                {Tuple.Create(6,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(6,"") },
                {Tuple.Create(6,"") },
            };
            var Expected = 30;
            var result = Yatzy.Scoring.CheckYatzy(rolledDice);
            Assert.AreEqual(Expected, result);
        }
    }
}
