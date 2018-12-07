/*using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowersOfHanoi_test
{
    [TestClass()]
    public class MoveCalculatorTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getMoves
        ///</summary>
        [TestMethod()]
        public void GetMovesTest()
        {
            int amountOfDisks = 3;
            Pole pole0 = new Pole(0);
            Pole pole1 = new Pole(1);
            Pole pole2 = new Pole(2);

            //Set expected moves
            List<Move> expectedMoves = new List<Move>();
            Move move1 = new Move(pole0, pole2);
            Move move2 = new Move(pole0, pole1);
            Move move3 = new Move(pole2, pole1);
            Move move4 = new Move(pole0, pole2);
            Move move5 = new Move(pole1, pole0);
            Move move6 = new Move(pole1, pole2);
            Move move7 = new Move(pole0, pole2);
            expectedMoves.Add(move1);
            expectedMoves.Add(move2);
            expectedMoves.Add(move3);
            expectedMoves.Add(move4);
            expectedMoves.Add(move5);
            expectedMoves.Add(move6);
            expectedMoves.Add(move7);

            //Get actual moves
            List<Move> actualMoves = MoveCalculator.GetMoves(amountOfDisks);

            //Assert
            Assert.AreEqual(expectedMoves.Count, actualMoves.Count);
            Assert.AreEqual(expectedMoves[0], actualMoves[0]);
            Assert.AreEqual(expectedMoves[1], actualMoves[1]);
            Assert.AreEqual(expectedMoves[2], actualMoves[2]);
            Assert.AreEqual(expectedMoves[3], actualMoves[3]);
            Assert.AreEqual(expectedMoves[4], actualMoves[4]);
            Assert.AreEqual(expectedMoves[5], actualMoves[5]);
            Assert.AreEqual(expectedMoves[6], actualMoves[6]);
        }

        /// <summary>
        ///A test for GetMoveCount
        ///</summary>
        [TestMethod()]
        public void GetMoveCountTest()
        {
            int actualMoveCount = MoveCalculator.GetMoveCount(3);
            int expectedMoveCount = 7;
            Assert.AreEqual(expectedMoveCount, actualMoveCount);

            actualMoveCount = MoveCalculator.GetMoveCount(4);
            expectedMoveCount = 15;
            Assert.AreEqual(expectedMoveCount, actualMoveCount);

            actualMoveCount = MoveCalculator.GetMoveCount(5);
            expectedMoveCount = 31;
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }
    }
}*/