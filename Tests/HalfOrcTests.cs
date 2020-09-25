using Races;
using Xunit;

namespace HalfOrcTests
{
    public class HalfOrcTests
    {
        [Fact]
        public void HalfOrcLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new HalfOrc().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // HalfOrcs know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void HalfOrcLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new HalfOrc().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void HalfOrcLanguageIncludesOrc()
        {
            // Arrange
            var Lang = new HalfOrc().GetLanguages();
            // Assert
            Assert.Contains("Orc", Lang);
        }

        [Fact]
        public void HalfOrcAlignmentNotNull()
        {
            // Arrange
            var Alignment = new HalfOrc().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void HalfOrcAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new HalfOrc().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new HalfOrc().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new HalfOrc().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInHalfOrcRange()
        {
            //Arrange
            var Age = new HalfOrc().GetAge();
            // Assert
            Assert.InRange(Age,14,75);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new HalfOrc().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new HalfOrc().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new HalfOrc().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new HalfOrc().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void STRAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new HalfOrc().GetAbilityScoreIncrease();
            // Act
            var STR = Scores.TryGetValue("STR", out var STRResult);
            // Assert
            Assert.True(STR);
        }

        [Fact]
        public void CONAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new HalfOrc().GetAbilityScoreIncrease();
            // Act
            var CON = Scores.TryGetValue("CON", out var CONResult);
            // Assert
            Assert.True(CON);
        }

        [Fact]
        public void STRAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new HalfOrc().GetAbilityScoreIncrease();
            // Act
            var STRValue = Scores["STR"];
            // Assert
            Assert.Equal(STRValue,2);

        }

        [Fact]
        public void CONAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new HalfOrc().GetAbilityScoreIncrease();
            // Act
            var CONValue = Scores["CON"];
            // Assert
            Assert.Equal(CONValue,1);

        }

    }
    
}