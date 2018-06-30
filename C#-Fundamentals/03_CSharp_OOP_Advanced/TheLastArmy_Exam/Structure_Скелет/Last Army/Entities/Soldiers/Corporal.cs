﻿using System.Collections.Generic;

public class Corporal:Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife",
    };
    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        this.OverallSkill = (this.Age + this.Experience) * OverallSkillMiltiplier;
    }

}

