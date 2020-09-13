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
            Dice.DiceTypes D20 = new DiceTypes();

            // Act
            var result = D20.RollD20();

            // Assert

            // Checks that result is of type int
            Assert.IsType<int>(result[0][0]);

            // Checks that result is within valid range
            Assert.InRange(result[0][0],1,20);
            
        }

        [Fact]
        public void D12ReturnsValidInt()
        {
            // Arrange
            Dice.DiceTypes D12 = new DiceTypes();
            
            // Act
            var result = D12.RollD12();

            // Assert

            // Checks that result is of type int
            Assert.IsType<int>(result[0][0]);

            // Checks that result is within valid range
            Assert.InRange(result[0][0],1,12);
            
        }

        [Fact]
        public void D10ReturnsValidInt()
        {
            // Arrange
            Dice.DiceTypes D10 = new DiceTypes();
            
            // Act
            var result = D10.RollD10();

            // Assert

            // Checks that result is of type int
            Assert.IsType<int>(result[0][0]);

            // Checks that result is within valid range
            Assert.InRange(result[0][0],1,10);
            
        }    

        [Fact]
        public void D8ReturnsValidInt()
        {
            // Arrange
            Dice.DiceTypes D8 = new DiceTypes();
            
            // Act
            var result = D8.RollD8();

            // Assert

            // Checks that result is of type int
            Assert.IsType<int>(result[0][0]);

            // Checks that result is within valid range
            Assert.InRange(result[0][0],1,8);
            
        }

        [Fact]
        public void D4ReturnsValidInt()
        {
            // Arrange
            Dice.DiceTypes D4 = new DiceTypes();
            
            // Act
            var result = D4.RollD4();

            // Assert

            // Checks that result is of type int
            Assert.IsType<int>(result[0][0]);

            // Checks that result is within valid range
            Assert.InRange(result[0][0],1,4);
            
        }

        [Fact]
        public void SixAbilitiyScoresReturned()
        {
            // Arrange
            Dice.DiceTypes x = new DiceTypes();
            
            // Act
            var result = x.ReturnAbilityScores();

            // Assert

            // Checks that array is not empty
            Assert.NotEmpty(result);

            // Checks that array is correct size
            Assert.Equal(6,result.Length);


            
        }
    }
    
}