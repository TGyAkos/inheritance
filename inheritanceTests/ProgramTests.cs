using System;
using System.IO; 

using inheritance;

namespace inheritanceTests
{
    [TestClass]
    public class ProgramTests
    {
        public TestContext TestContext { get; set; }
        private Program Program { get; set; }
        private string NoLakcim;

        [TestInitialize]
        public void Initialize()
        {
            Program = new Program();
            
            if (TestContext.Properties.Contains("NoLakcim"))
            {
                NoLakcim = TestContext.Properties["Nolakcim"] as string;
            }

        }
        [TestCleanup]
        public void Cleanup()
        {
            Program = null;
        }
        [TestMethod]
        public void Int_WithValidData_ReturnsInt()
        {
            // Arrange
            int firstInt = 123;
            int secondInt = 456;
            int result;
            
            // Act
            result = Program.AddInt(firstInt, secondInt);

            // Assert
            Assert.AreEqual(579, result);

        }

        [TestMethod]
        public void Str_WithValidData_ReturnsAppendedStr()
        {
            // Arrange
            string firstString = "asd";
            string secondString = "fgh";
            string result;
            Program program = new Program();

            // Act
            result = program.AddString(firstString, secondString);

            // Assert
            Assert.AreEqual("asdfgh", result);

        }
    }
}