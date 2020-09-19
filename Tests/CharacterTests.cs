using Xunit;
using Character;

namespace CharacterTests
{
    public class CharacterTest
    {
        [Fact]
        public void RandomFirstNameIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomName(testCharacter.Gender, testCharacter.Race.GetName());
            // Assert
            Assert.NotNull(testCharacter.FirstName);
        }

        [Fact]
        public void RandomLastNameIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomName(testCharacter.Gender, testCharacter.Race.GetName());
            // Assert
            Assert.NotNull(testCharacter.LastName);
        }

        [Fact]
        public void RaceIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomRace();
            // Assert
            Assert.NotNull(testCharacter.Race);

        }
    
        [Fact]
        public void GenderIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomGender();
            // Assert
            Assert.NotNull(testCharacter.Gender);
        }


    }
}
