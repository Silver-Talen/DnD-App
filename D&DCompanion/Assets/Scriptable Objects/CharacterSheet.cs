using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : ScriptableObject
{
    public string characterName, characterClass, level, race;
    public Alignment alignment;
    public int experience, maxHealth, currentHealth;
    public int inspiration, proficiencyBonus, armorClass, initiative, speed;
    // Base Stats
    public int strength, dexterity, constitution, intelligence, wisdom, charisma;
    // Saving Throws
    public int strengthSV, dexteritySV, constitutionSV, intelligenceSV, wisdomSV, charismaSV;
    //Skills
    public int acrobatics, animalHandling, arcana, athletics, deception, history, insight,
               intimidation, investigation, medicine, nature, perception, performance, persuasion,
               religion, sleightOfHand, stealth, survival;

    public enum Alignment
    {
        LAWFUL_GOOD,
        NEUTRAL_GOOD,
        CHAOTIC_GOOD,
        LAWFUL_NEUTRAL,
        NEUTRAL,
        CHAOTIC_NEUTRAL,
        LAWFUL_EVIL,
        NEUTRAL_EVIL,
        CHAOTIC_EVIL
    }
}