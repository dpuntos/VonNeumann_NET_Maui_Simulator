namespace VonNeumann.Computer.Test
{
    [TestClass()]
    public class MemoryUnitTests
    {
        [TestMethod]
        public void MemoryUnit_Constructor_SetsMemorySize()
        {
            // Arrange
            int memorySize = 1024;

            // Act
            MemoryUnit memoryUnit = new MemoryUnit(memorySize);

            // Assert
            Assert.AreEqual(memorySize, memoryUnit.MemorySize);
        }

        [TestMethod]
        public void MemoryUnit_Indexer_Get_ReturnsCorrectValue()
        {
            // Arrange
            MemoryUnit memoryUnit = new MemoryUnit(1024);
            int index = 0;
            byte expectedValue = 42;
            memoryUnit[index] = expectedValue;

            // Act
            byte actualValue = memoryUnit[index];

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MemoryUnit_Indexer_Set_SetsCorrectValue()
        {
            // Arrange
            MemoryUnit memoryUnit = new MemoryUnit(1024);
            int index = 0;
            byte value = 42;

            // Act
            memoryUnit[index] = value;

            // Assert
            Assert.AreEqual(value, memoryUnit[index]);
        }
    }
}
