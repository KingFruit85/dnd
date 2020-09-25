using Races;
using Xunit;

namespace GnomeTests
{
    public class GnomeTests
    {
        [Fact]
        public void GnomeLanguageAddedCorrectly()
        {
            // Arrange
            var Lang = new Gnome().GetLanguages();
            // Act
            var actual = Lang.Count;
            // Assert
            // Gnomes know two languages at level 1
            // One being Common, the other random
            Assert.Equal(2,actual);
        }

        [Fact]
        public void GnomeLanguageIncludesCommon()
        {
            // Arrange
            var Lang = new Gnome().GetLanguages();
            // Assert
            Assert.Contains("Common", Lang);
        }

        [Fact]
        public void GnomeLanguageIncludesGnomish()
        {
            // Arrange
            var Lang = new Gnome().GetLanguages();
            // Assert
            Assert.Contains("Gnomish", Lang);
        }

        [Fact]
        public void GnomeAlignmentNotNull()
        {
            // Arrange
            var Alignment = new Gnome().GetAlignment();
            //Assert
            Assert.NotNull(Alignment);
        }

        [Fact]
        public void GnomeAlignmentIsCorrectType()
        {
            // Arrange
            var Alignment = new Gnome().GetAlignment();
            //Assert
            Assert.IsType(typeof(string), Alignment);
        }

        [Fact]
        public void AgeNotNull()
        {
            //Arrange
            var Age = new Gnome().GetAge();
            // Assert
            Assert.NotNull(Age);
        }

        [Fact]
        public void AgeCorrectType()
        {
            //Arrange
            var Age = new Gnome().GetAge();
            // Assert
            Assert.IsType(typeof(int),Age);
        }

        [Fact]
        public void AgeInGnomeRange()
        {
            //Arrange
            var Age = new Gnome().GetAge();
            // Assert
            Assert.InRange(Age,40,500);
        }

        [Fact]
        public void SizeIsNotNull()
        {
            // Arrange 
            var Size = new Gnome().GetSize();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SizeIsCorrectType()
        {
            // Arrange 
            var Size = new Gnome().GetSize();
            // Assert
            Assert.IsType(typeof(string),Size);
        }

        [Fact]
        public void SpeedIsNotNull()
        {
            // Arrange 
            var Size = new Gnome().GetSpeed();
            // Assert
            Assert.NotNull(Size);
        }

        [Fact]
        public void SpeedIsCorrectType()
        {
            // Arrange 
            var Size = new Gnome().GetSpeed();
            // Assert
            Assert.IsType(typeof(int), Size);
        }

        [Fact]
        public void INTAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Gnome().GetAbilityScoreIncrease();
            // Act
            var INT = Scores.TryGetValue("INT", out var INTResult);
            // Assert
            Assert.True(INT);
        }

        [Fact]
        public void CONAbilityScoreNotNull()
        {
            // Arrange 
            var Scores = new Gnome().GetAbilityScoreIncrease();
            // Act
            var CON = Scores.TryGetValue("CON", out var CONResult);
            // Assert
            Assert.True(CON);
        }

        [Fact]
        public void INTAbilityScoreIncreaseEquals2()
        {
            // Arrange 
            var Scores = new Gnome().GetAbilityScoreIncrease();
            // Act
            var INTValue = Scores["INT"];
            // Assert
            Assert.Equal(INTValue,2);

        }

        [Fact]
        public void CONAbilityScoreIncreaseEquals1()
        {
            // Arrange 
            var Scores = new Gnome().GetAbilityScoreIncrease();
            // Act
            var CONValue = Scores["CON"];
            // Assert
            Assert.Equal(CONValue,1);

        }

    }
    
}