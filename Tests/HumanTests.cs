using Races;
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
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void HumanAlignmentNotNullAndCorrectType()
        {
            // Arrange
            var Alignment = new Human().GetAlignment();
            
            //Assert
            Assert.NotNull(Alignment);
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNullAndCorrectType()
        {
            //Arrange
            var Age = new Human().GetAge();

            // Assert
            Assert.NotNull(Age);
            Assert.IsType(typeof(int),Age);
            Assert.InRange(Age,18,65);
        }

        [Fact]
        public void SizeIsNotNullAndCorrectType()
        {
            // Arrange 
            var Size = new Human().GetSize();

            // Assert
            Assert.NotNull(Size);
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNullAndCorrectType()
        {
            // Arrange 
            var Size = new Human().GetSpeed();

            // Assert
            Assert.NotNull(Size);
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void AbilityScoreIncreasesNotNullAndCorrectValue()
        {
            // Arrange
            var Scores = new Human().GetAbilityScoreIncrease();
            // Act

            int STRResult;
            var STR = Scores.TryGetValue("STR", out STRResult);
            var STRValue = Scores["STR"];

            int DEXResult;
            var DEX = Scores.TryGetValue("DEX", out DEXResult);
            var DEXValue = Scores["DEX"];

            int CONResult;
            var CON = Scores.TryGetValue("CON", out CONResult);
            var CONValue = Scores["CON"];

            int INTResult;
            var INT = Scores.TryGetValue("INT", out INTResult);
            var INTValue = Scores["INT"];

            int CHAResult;
            var CHA = Scores.TryGetValue("CHA", out CHAResult);
            var CHAValue = Scores["CHA"];

            int WISResult;
            var WIS = Scores.TryGetValue("WIS", out WISResult);
            var WISValue = Scores["WIS"];

            // Assert

            Assert.True(STR);
            Assert.Equal(STRValue,1);

            Assert.True(DEX);
            Assert.Equal(DEXValue,1);

            Assert.True(CON);
            Assert.Equal(CONValue,1);

            Assert.True(INT);
            Assert.Equal(INTValue,1);

            Assert.True(CHA);
            Assert.Equal(CHAValue,1);

            Assert.True(WIS);
            Assert.Equal(WISValue,1);
            
        }
    }
    
}