using Character;

using Xunit;

namespace HumanTests
{
    public class HumanTests
    {
        [Fact]
        public void HumanLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new Human().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // Humans know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void HumanLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new Human().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void HumanAlignmentNotNull()
        {
            // Arrange
            var Alignment = new Human().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void HumanAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new Human().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }



        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new Human().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new Human().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInHUmanRange()
        {
            //Arrange
            var Age = new Human().GetAge();
            // Assert
            Assert.InRange(Age,18,65);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new Human().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new Human().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new Human().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new Human().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void STRAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var STR = Scores.TryGetValue("STR", out var STRResult);
            // Assert
            Assert.True(STR);
        }

        [Fact]
        public void DEXAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var DEX = Scores.TryGetValue("DEX", out var DEXResult);
            // Assert
            Assert.True(DEX);
        }

        [Fact]
        public void CONAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var CON = Scores.TryGetValue("CON", out var CONResult);
            // Assert
            Assert.True(CON);
        }

        [Fact]
        public void INTAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var INT = Scores.TryGetValue("INT", out var INTResult);
            // Assert
            Assert.True(INT);
        }

        [Fact]
        public void CHAAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var CHA = Scores.TryGetValue("CHA", out var CHAResult);
            // Assert
            Assert.True(CHA);
        }

        [Fact]
        public void WISAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var WIS = Scores.TryGetValue("WIS", out var WISResult);
            // Assert
            Assert.True(WIS);
        }

        [Fact]
        public void STRAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var STRValue = Scores["STR"];
            // Assert
            Assert.Equal(STRValue,1);

        }

        [Fact]
        public void DEXAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var DEXValue = Scores["DEX"];
            // Assert
            Assert.Equal(DEXValue,1);

        }

        [Fact]
        public void CONAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var CONValue = Scores["CON"];
            // Assert
            Assert.Equal(CONValue,1);

        }

        [Fact]
        public void INTAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var INTValue = Scores["INT"];
            // Assert
            Assert.Equal(INTValue,1);

        }

        [Fact]
        public void CHAAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var CHAValue = Scores["CHA"];
            // Assert
            Assert.Equal(CHAValue,1);

        }

        [Fact]
        public void WISAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act
            var WISValue = Scores["WIS"];
            // Assert
            Assert.Equal(WISValue,1);

        }

    }
    
}