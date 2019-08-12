using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DESCRIPTION: This is the Character class used in character creation
 *              This is also the Data Container for the appliation
 */



namespace COMP123_S2019_FinalTestB.Objects
{
    public class Character
    {
        // Character Abilities
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Constitution { get; set; }
        public string Intelligence { get; set; }
        public string Wisdom { get; set; }
        public string Charisma { get; set; }

        // Secondary Abilities
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        // Character Class
        public CharacterClass Class { get; set; }
        public int Level { get; set; }

        // Equipment
        List<Item> Inventory;

        // Constructor 
        Character()
        {
            this.Inventory = new List<Item>();
        }
    }
}
