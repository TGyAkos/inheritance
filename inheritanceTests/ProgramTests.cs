using inheritance;

namespace inheritanceTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Int_WithValidData_ReturnsInt()
        {
            // Arrange
            int firstInt = 123;
            int secondInt = 456;
            int result;
            Program program = new Program();

            // Act
            result = program.AddInt(firstInt, secondInt);

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