using System;
using System.Collections.Generic;

namespace Character
{
    public class AbilityScore
    {
        private int[] RawScores = new DiceTypes().ReturnAbilityScores();
        private Dictionary<string, int> AbilityScores = new Dictionary<string, int>()
        {
            {"STR",0},
            {"DEX",0},
            {"CON",0},
            {"INT",0},
            {"WIS",0},
            {"CHA",0},
        };

        public void Arrange(string characterClassName)
        {
           switch (characterClassName)
           {
               case "Bard":ArrangeBardScores();
                    break;

               case "Barbarian":
                    ArrangeBarbarianScores();
                    break;

               case "Cleric":
                    ArrangeClericScores();
                    break;

               case "Fighter":   
                    ArrangeFighterScores();
                    break;

               case "Monk":
                    ArrangeMonkScores();
                    break;

               case "Paladin":
                    ArrangePaladinScores();
                    break;

               case "Ranger":
                    ArrangeRangerScores();
                    break;

               case "Rogue":
                    ArrangeRogueScores();
                    break;

               case "Sorcerer":
                    ArrangeSorcererScores();
                    break;

               case "Warlock":
                    ArrangeWarlockScores();
                    break;

               case "Wizard":
                    ArrangeWizardScores();
                    break;

               case "Druid":
                    ArrangeDruidScores();
                    break;

               default: throw new Exception("class name wasn't caught");
           }

        }

        public void ArrangeBardScores()
        {
            AbilityScores["CHA"] = RawScores[0];
            AbilityScores["DEX"] = RawScores[1];
            AbilityScores["CON"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["STR"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void ArrangeBarbarianScores()
        {
            AbilityScores["STR"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["DEX"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void ArrangeMonkScores()
        {
            AbilityScores["DEX"] = RawScores[0];
            AbilityScores["WIS"] = RawScores[1];
            AbilityScores["CON"] = RawScores[2];
            AbilityScores["STR"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void ArrangeClericScores()
        {
            AbilityScores["WIS"] = RawScores[0];
            AbilityScores["STR"] = RawScores[1];
            AbilityScores["CON"] = RawScores[2];
            AbilityScores["DEX"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }


        public void ArrangeDruidScores()
        {
            AbilityScores["WIS"] = RawScores[0];
            AbilityScores["DEX"] = RawScores[1];
            AbilityScores["CON"] = RawScores[2];
            AbilityScores["CHA"] = RawScores[3];
            AbilityScores["INT"] = RawScores[4];
            AbilityScores["STR"] = RawScores[5];    
        }

        public void ArrangePaladinScores()
        {
            AbilityScores["STR"] = RawScores[0];
            AbilityScores["CHA"] = RawScores[1];
            AbilityScores["CON"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["DEX"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void ArrangeRangerScores()
        {
            AbilityScores["DEX"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["WIS"] = RawScores[2];
            AbilityScores["STR"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void ArrangeRogueScores()
        {
            AbilityScores["DEX"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["WIS"] = RawScores[2];
            AbilityScores["CHA"] = RawScores[3];
            AbilityScores["INT"] = RawScores[4];
            AbilityScores["STR"] = RawScores[5];    
        }

        public void ArrangeSorcererScores()
        {
            AbilityScores["CHA"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["INT"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["DEX"] = RawScores[4];
            AbilityScores["STR"] = RawScores[5];    
        }

        public void ArrangeWarlockScores()
        {
            AbilityScores["CHA"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["DEX"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["INT"] = RawScores[4];
            AbilityScores["STR"] = RawScores[5];    
        }

        public void ArrangeWizardScores()
        {
            AbilityScores["INT"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["DEX"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["STR"] = RawScores[5];    
        }

        public void ArrangeFighterScores()
        {
            AbilityScores["STR"] = RawScores[0];
            AbilityScores["CON"] = RawScores[1];
            AbilityScores["DEX"] = RawScores[2];
            AbilityScores["WIS"] = RawScores[3];
            AbilityScores["CHA"] = RawScores[4];
            AbilityScores["INT"] = RawScores[5];    
        }

        public void setStrengthScore(int score)
        {
            AbilityScores["STR"] = score;
        }

        public void setDexterityScore(int score)
        {
            AbilityScores["DEX"] = score;
        }

        public void setConstitutionScore(int score)
        {
            AbilityScores["CON"] = score;
        }

        public void setIntelligenceScore(int score)
        {
            AbilityScores["INT"] = score;
        }

        public void setWisdomScore(int score)
        {
            AbilityScores["WIS"] = score;
        }

        public void setCharismaScore(int score)
        {
            AbilityScores["CHA"] = score;
        }
    }
}