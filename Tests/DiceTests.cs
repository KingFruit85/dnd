using Xunit;
using Dice;

namespace DiceTests
{
    public class DiceTest
    {
        [Fact]
        public void D20ReturnsValidInt()
        {
            // Arrange
            var D20 = new DiceTypes().RollD20();
            // Assert
            Assert.IsType<int>(D20[0][0]);
        }

        [Fact]
        public void D20ReturnsWithinRange()
        {
            // Arrange
            var D20 = new DiceTypes().RollD20();
            // Assert
            Assert.InRange(D20[0][0],1,20);
        }

        [Fact]
        public void D12ReturnsValidInt()
        {
            // Arrange
            var D12 = new DiceTypes().RollD12();
            // Assert
            Assert.IsType<int>(D12[0][0]);
        }

        [Fact]
        public void D12ReturnsWithinRange()
        {
            // Arrange
            var D12 = new DiceTypes().RollD12();;
            // Assert
            Assert.InRange(D12[0][0],1,12);
        }

        [Fact]
        public void D10ReturnsValidInt()
        {
            // Arrange
            var D10 = new DiceTypes().RollD10();
            // Assert
            Assert.IsType<int>(D10[0][0]);
        } 

        [Fact]
        public void D10ReturnsWithinRange()
        {
            // Arrange
            var D10 = new DiceTypes().RollD10();
            // Assert
            Assert.InRange(D10[0][0],1,10);
        }  

        [Fact]
        public void D8ReturnsValidInt()
        {
            // Arrange
            var D8 = new DiceTypes().RollD8();
            // Assert
            Assert.IsType<int>(D8[0][0]);
        }

        [Fact]
        public void D8ReturnsWithinRange()
        {
            // Arrange
            var D8 = new DiceTypes().RollD8();
            // Assert
            Assert.InRange(D8[0][0],1,8);
        }

        [Fact]
        public void D4ReturnsValidInt()
        {
            // Arrange
            var D4 = new DiceTypes().RollD4();
            // Assert
            Assert.IsType<int>(D4[0][0]);
        }

        [Fact]
        public void D4ReturnsWithinRange()
        {
            // Arrange
            var D4 = new DiceTypes().RollD4();
            // Assert
            Assert.InRange(D4[0][0],1,4);
        }

        [Fact]
        public void SixAbilitiyScoresReturned()
        {
            // Arrange
            var scores = new DiceTypes().ReturnAbilityScores();
            // Assert
            Assert.Equal(6,scores.Length);
        }

        [Fact]
        public void SixAbilitiyScoresNotNull()
        {
            // Arrange
            var scores = new DiceTypes().ReturnAbilityScores();
            // Assert
            Assert.NotNull(scores);
        }
    }
    
}