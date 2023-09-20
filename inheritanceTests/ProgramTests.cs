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
    }
}