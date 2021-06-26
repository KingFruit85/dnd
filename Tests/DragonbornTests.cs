using Races;
using Xunit;

namespace DragonbornTests
{
    public class DragonbornTests
    {
        [Fact]
        public void DragonbornLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new Dragonborn().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // Dragonborn know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void DragonbornLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new Dragonborn().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void DragonbornLanguageIncludesDraconic()
        {
            // Arrange
            var Lang = new Dragonborn().GetLanguages();
            // Assert
            Assert.Contains("Draconic", Lang);
        }

        [Fact]
        public void DragonbornAlignmentNotNull()
        {
            // Arrange
            var Alignment = new Dragonborn().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void DragonbornAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new Dragonborn().GetAlignment();
            //Assert
            Assert.IsType<string>(Alignment);
        }

        [Fact]
        public void AgeNotZero()
        {
            //Arrange
            var Age = new Dragonborn().GetAge();
            // Assert
            Assert.True(Age > 0);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new Dragonborn().GetAge();
            // Assert
            Assert.IsType<int>(Age);
        }

        [Fact]
        public void AgeInDragonbornRange()
        {
            //Arrange
            var Age = new Dragonborn().GetAge();
            // Assert
            Assert.InRange(Age,20,250);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new Dragonborn().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new Dragonborn().GetSize();
            // Assert
            Assert.IsType<string>(Size);
        }

        [Fact]
        public void SpeedIsNotZero()
        {
            // Arrange 
            var Size = new Dragonborn().GetSpeed();
            // Assert
            Assert.True(Size > 0);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new Dragonborn().GetSpeed();
            // Assert
            Assert.IsType<int>(Size);
        }

        [Fact]
        public void STRAbilityIsNotNull()
        {
            // Arrange 
            var Scores = new Dragonborn().GetAbilityScoreIncrease();
            // Act
            var STR = Scores.TryGetValue("STR", out var STRResult);
            // Assert
            Assert.True(STR);
        }

        [Fact]
        public void CHAAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Dragonborn().GetAbilityScoreIncrease();
            // Act
            var CHA = Scores.TryGetValue("CHA", out var CHAResult);
            // Assert
            Assert.True(CHA);
        }

        [Fact]
        public void STRAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Dragonborn().GetAbilityScoreIncrease();
            // Act
            var STRValue = Scores["STR"];
            // Assert
            Assert.Equal(2,STRValue);

        }

        [Fact]
        public void CHAAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Dragonborn().GetAbilityScoreIncrease();
            // Act
            var CHAValue = Scores["CHA"];
            // Assert
            Assert.Equal(1,CHAValue);

        }

        [Fact]
        public void DraconicAncestryIsCorrectType()
        {
            // Arrange
            var DraconicAncestry = new Dragonborn().GetDraconicAncestry();

            // Assert
            Assert.IsType<GenericRace.DraconicAncestryDetails>(DraconicAncestry);
        }

    }
    
}