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
            testCharacter.SetRandomName(testCharacter.GetGender(), testCharacter.GetRace().GetName());
            // Assert
            Assert.NotNull(testCharacter.GetFirstName());
        }

        [Fact]
        public void RandomLastNameIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomName(testCharacter.GetGender(), testCharacter.GetRace().GetName());
            // Assert
            Assert.NotNull(testCharacter.GetLastName());
        }

        [Fact]
        public void RaceIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomRace();
            // Assert
            Assert.NotNull(testCharacter.GetRace());

        }
    
        [Fact]
        public void GenderIsNotNull()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            // Act
            testCharacter.SetRandomGender();
            // Assert
            Assert.NotNull(testCharacter.GetGender());
        }


    }
}
