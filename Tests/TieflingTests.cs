using Character;

using Xunit;

namespace TieflingTests
{
    public class TieflingTests
    {
        [Fact]
        public void TieflingLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new Tiefling().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // Tieflings know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void TieflingLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new Tiefling().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

                [Fact]
        public void TieflingLanguageIncludesInfernal()
        {
            // Arrange
            var Lang = new Tiefling().GetLanguages();
            // Assert
            Assert.Contains("Infernal", Lang);
        }

        [Fact]
        public void TieflingAlignmentNotNull()
        {
            // Arrange
            var Alignment = new Tiefling().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void TieflingAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new Tiefling().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new Tiefling().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new Tiefling().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInTieflingRange()
        {
            //Arrange
            var Age = new Tiefling().GetAge();
            // Assert
            Assert.InRange(Age,18,70);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new Tiefling().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new Tiefling().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new Tiefling().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new Tiefling().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void INTAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Tiefling().GetAbilityScoreIncrease();
            // Act
            var INT = Scores.TryGetValue("INT", out var INTResult);
            // Assert
            Assert.True(INT);
        }

        [Fact]
        public void CHAAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Tiefling().GetAbilityScoreIncrease();
            // Act
            var CHA = Scores.TryGetValue("CHA", out var CHAResult);
            // Assert
            Assert.True(CHA);
        }

        [Fact]
        public void INTAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Tiefling().GetAbilityScoreIncrease();
            // Act
            var INTValue = Scores["INT"];
            // Assert
            Assert.Equal(INTValue,1);

        }

        [Fact]
        public void CHAAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Tiefling().GetAbilityScoreIncrease();
            // Act
            var CHAValue = Scores["CHA"];
            // Assert
            Assert.Equal(CHAValue,2);

        }

    }
    
}