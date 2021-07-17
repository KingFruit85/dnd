using Character;

using Xunit;

namespace HalflingTests
{
    public class HalflingTests
    {
        [Fact]
        public void HalflingLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new Halfling().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // Halflings know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void HalflingLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new Halfling().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void HalflingLanguageIncludesHalfling()
        {
            // Arrange
            var Lang = new Halfling().GetLanguages();
            // Assert
            Assert.Contains("Halfling", Lang);
        }

        [Fact]
        public void HalflingAlignmentNotNull()
        {
            // Arrange
            var Alignment = new Halfling().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void HalflingAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new Halfling().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new Halfling().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new Halfling().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInHalflingRange()
        {
            //Arrange
            var Age = new Halfling().GetAge();
            // Assert
            Assert.InRange(Age,20,250);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new Halfling().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new Halfling().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new Halfling().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new Halfling().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void STRAbilityIsNull()
        {
            // Arrange 
            var Scores = new Halfling().GetAbilityScoreIncrease();
            // Act
            var STR = Scores.TryGetValue("STR", out var STRResult);
            // Assert
            Assert.False(STR);
        }

        [Fact]
        public void DEXAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Halfling().GetAbilityScoreIncrease();
            // Act
            var DEX = Scores.TryGetValue("DEX", out var DEXResult);
            // Assert
            Assert.True(DEX);
        }

        [Fact]
        public void CHAAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Halfling().GetAbilityScoreIncrease();
            // Act
            var CHA = Scores.TryGetValue("CHA", out var CHAResult);
            // Assert
            Assert.True(CHA);
        }

        [Fact]
        public void DEXAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Halfling().GetAbilityScoreIncrease();
            // Act
            var DEXValue = Scores["DEX"];
            // Assert
            Assert.Equal(DEXValue,2);

        }

        [Fact]
        public void CHAAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Halfling().GetAbilityScoreIncrease();
            // Act
            var CHAValue = Scores["CHA"];
            // Assert
            Assert.Equal(CHAValue,1);

        }

    }
    
}