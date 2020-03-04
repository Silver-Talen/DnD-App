using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Data
{
    public string          Size;
    public string          Type;
    public string          Subtype;
    public string          Alignment;
    public int             ArmorClass;
    public int             HitPoints;
    public string          HitDice;
    public string    Speed;
    public int             Strength;
    public int             Dexterity;
    public int             Constitution;
    public int             Intelligence;
    public int             Wisdom;
    public int             Charisma;
    public string    Proficiencies;
    public string    DamageVulnerabilities;
    public string    DamageResistances;
    public string    DamageImmunities;
    public string    ConditionImmunities;
    public string    Senses;
    public string          Languages;
    public int             ChallengeRating;
    public string    SpecialAbilities;
    public string    Actions;

    public Monster(string index, string name, string url, string size, string type, string subtype, string alignment, int armorClass, int hitPoints, string hitDice, string speed, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, string proficiencies, string damageVulnerabilities, string damageResistances, string damageImmunities, string conditionImmunities, string senses, string languages, int challengeRating, string specialAbilities, string actions) : base(index, name, url)
    {
        Size = size;
        Type = type;
        Subtype = subtype;
        Alignment = alignment;
        ArmorClass = armorClass;
        HitPoints = hitPoints;
        HitDice = hitDice;
        Speed = speed;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Proficiencies = proficiencies;
        DamageVulnerabilities = damageVulnerabilities;
        DamageResistances = damageResistances;
        DamageImmunities = damageImmunities;
        ConditionImmunities = conditionImmunities;
        Senses = senses;
        Languages = languages;
        ChallengeRating = challengeRating;
        SpecialAbilities = specialAbilities;
        Actions = actions;
    }
}
