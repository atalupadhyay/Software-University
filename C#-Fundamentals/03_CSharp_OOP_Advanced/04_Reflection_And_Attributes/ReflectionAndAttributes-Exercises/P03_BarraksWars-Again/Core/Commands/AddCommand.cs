﻿using _03BarracksFactory.Contracts;

public class AddCommand:Command
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data)
    {
        this.Repository = repository;
        this.UnitFactory = unitFactory;
    }

    protected IRepository Repository
    {
        get { return this.repository; }
        set { this.repository = value; }
    }

    protected IUnitFactory UnitFactory
    {
        get { return this.unitFactory; }
        set { this.unitFactory = value; }
    }
    
    public override string Execute()
    {
        string unitType = this.Data[1];
        IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
        this.Repository.AddUnit(unitToAdd);
        string output = unitType + " added!";

        return output;
    }
}

