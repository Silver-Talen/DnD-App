using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Data
{
    public string                               Size;
    public string                               Type;
    public string                               Subtype;
    public string                               Alignment;
    public int                                  ArmorClass;
    public int                                  HitPoints;
    public string                               HitDice;
    public Dictionary<string, string>           Speed;
    public int                                  Strength;
    public int                                  Dexterity;
    public int                                  Constitution;
    public int                                  Intelligence;
    public int                                  Wisdom;
    public int                                  Charisma;
    public List<Dictionary<string, string>>     Proficiencies;
    public List<string>                         DamageVulnerabilities;
    public List<string>                         DamageResistances;
    public List<string>                         DamageImmunities;
    public List<Dictionary<string, string>>     ConditionImmunities;
    public Dictionary<string, string>           Senses;
    public string                               Languages;
    public float                                ChallengeRating;
    public List<Dictionary<string, string>>     SpecialAbilities;
    public List<Dictionary<string, string>>     Actions;

    public Monster(string index, string name, string url) : base(index, name, url)
    {

    }

}
