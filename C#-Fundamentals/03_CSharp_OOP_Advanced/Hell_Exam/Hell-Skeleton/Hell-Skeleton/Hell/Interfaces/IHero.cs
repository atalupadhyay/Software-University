﻿using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    void AddItem(IItem item);

    void AddRecipe(IRecipe recipe);

    long Strength { get; }

    long Agility { get; }

    long Intelligence { get; }

    long HitPoints { get; }

    long Damage { get; }

    ICollection<IItem> Items { get; }

    long PrimaryStats { get; }

    long SecondaryStats { get; }
}