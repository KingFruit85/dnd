using Xunit;
using Character;

namespace AbilityScoreTests
{
    public class AbilityScoreTest
    {
        [Fact]
        public void CorrectAbilityScoreModifersAreReturned()
        {
            // Arrange
            RandomCharacter testCharacter = new RandomCharacter();
            AbilityScore AS = new AbilityScore();

            var scores = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,141,516,17,17,19,20,21,22};

            // Assert
            foreach (var score in scores)
            {
                var mod = AS.getAbilityScoreModifier(score);
                
                Assert.Equal(mod, (score -10 /2));
            }

        }
        
    }
}