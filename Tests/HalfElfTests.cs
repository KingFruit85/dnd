using Character;

using Xunit;

namespace HalfElfTests
{
    public class HalfElfTests
    {
        [Fact]
        public void HalfElfLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new HalfElf().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // HalfElfs know two languages at level 1
            // One being Common, the other random
            Assert.Equal(3,actual);
        }

        [Fact]
        public void HalfElfLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new HalfElf().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void HalfElfLanguageIncludesInfernal()
        {
            // Arrange
            var Lang = new HalfElf().GetLanguages();
            // Assert
            Assert.Contains("Elvish", Lang);
        }

        [Fact]
        public void HalfElfAlignmentNotNull()
        {
            // Arrange
            var Alignment = new HalfElf().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void HalfElfAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new HalfElf().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new HalfElf().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new HalfElf().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInHalfElfRange()
        {
            //Arrange
            var Age = new HalfElf().GetAge();
            // Assert
            Assert.InRange(Age,20,180);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new HalfElf().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new HalfElf().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new HalfElf().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new HalfElf().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void CHAAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new HalfElf().GetAbilityScoreIncrease();
            // Act
            var CHA = Scores.TryGetValue("CHA", out var CHAResult);
            // Assert
            Assert.True(CHA);
        }

        [Fact]
        public void CHAAbilityScoreIncreaseEquals2()
        {
            // Arrange 
            var Scores = new HalfElf().GetAbilityScoreIncrease();
            // Act
            var CHAValue = Scores["CHA"];
            // Assert
            Assert.Equal(CHAValue,2);

        }

    }
    
}