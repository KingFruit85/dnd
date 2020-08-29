using Xunit;
using Character;

namespace dnd
{
    public class CharacterTest
    {
        [Fact]
        public void RandomFirstNameIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomName();
            // Assert
            Assert.NotNull(testCharacter.FirstName);
        }

        [Fact]
        public void RandomLastNameIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomName();
            // Assert
            Assert.NotNull(testCharacter.LastName);
        }

        [Fact]
        public void RaceIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            // testCharacter.SetRandomRace();
            // Assert
            Assert.NotNull(testCharacter.Race);

        }
    }
}
