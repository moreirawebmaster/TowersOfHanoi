/*
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*using TowersOfHanoi;#1#

namespace TowersOfHanoi_test
{
    /// <summary>
    ///This is a test class for GameStateTest and is intended
    ///to contain all GameStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameStateTest
    {
        private TestContext testContextInstance;
        int numberOfDisks = 3;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        ///A test for RestartGame
        ///RestartGame should place all the disks on the first pole and reset the move count
        ///</summary>
        [TestMethod()]
        public void RestartGameTest()
        {   
            GameState.RestartGame(numberOfDisks);

            //Set expected values
            int expectedMoveCount = 0;
            int expectedDiskCountForPole0 = 3;
            int expectedDiskCountForPole1 = 0;
            int expectedDiskCountForPole2 = 0;

            //Get actual values
            int actualMoveCount = GameState.MoveCount;
            int actualDiskCountForPole0 = GameState.Poles[0].Disks.Count;
            int actualDiskCountForPole1 = GameState.Poles[1].Disks.Count;
            int actualDiskCountForPole2 = GameState.Poles[2].Disks.Count;

            //Assert
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
            Assert.AreEqual(expectedDiskCountForPole0, actualDiskCountForPole0);
            Assert.AreEqual(expectedDiskCountForPole1, actualDiskCountForPole1);
            Assert.AreEqual(expectedDiskCountForPole2, actualDiskCountForPole2);
        }

        /// <summary>
        ///A test for IsSolved
        ///</summary>
        [TestMethod()]
        public void IsSolvedTest()
        {
            GameState.RestartGame(numberOfDisks);

            bool expectedBefore = false; 
            bool actualBefore = GameState.IsSolved();
            solveGame();
            bool expectedAfter = true;
            bool actualAfter = GameState.IsSolved();

            //Assert 
            Assert.AreEqual(expectedBefore, actualBefore);
            Assert.AreEqual(expectedAfter, actualAfter);
        }

        /// <summary>
        ///Test the game state after a move
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            GameState.RestartGame(numberOfDisks);
            Move move = new Move(0, 2);

            //Set expected values
            int expectedMoveCount = 1;
            int expectedDiskCountForPole0 = 2;
            int expectedDiskCountForPole1 = 0;
            int expectedDiskCountForPole2 = 1;
            
            //Get actual values
            int actualMoveCount = GameState.MakeMove(move);
            int actualDiskCountForPole0 = GameState.Poles[0].Disks.Count;
            int actualDiskCountForPole1 = GameState.Poles[1].Disks.Count;
            int actualDiskCountForPole2 = GameState.Poles[2].Disks.Count;

            //Assert
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
            Assert.AreEqual(expectedDiskCountForPole0, actualDiskCountForPole0);
            Assert.AreEqual(expectedDiskCountForPole1, actualDiskCountForPole1);
            Assert.AreEqual(expectedDiskCountForPole2, actualDiskCountForPole2);
        }

        //-------- Helper methods ----------------
        private void solveGame()
        {
            List<Move> moves = MoveCalculator.GetMoves(numberOfDisks);
            foreach (Move move in moves)
            {
                GameState.MakeMove(move);
            }
        }            

    }
}

*/
