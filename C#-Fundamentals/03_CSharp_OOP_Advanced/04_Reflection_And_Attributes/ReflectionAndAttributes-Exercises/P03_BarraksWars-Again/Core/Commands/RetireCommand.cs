﻿using System;
using _03BarracksFactory.Contracts;

public class RetireCommand : Command
{
    private IRepository repository;

    public RetireCommand(string[] data, IRepository repository) : base(data)
    {
        this.Repository = repository;
    }

    protected IRepository Repository
    {
        get { return this.repository; }
        set { this.repository = value; }
    }
    
    public override string Execute()
    {
        string unitType = this.Data[1];

        try
        {
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
        catch (Exception e)
        {
            throw new ArgumentException("No such units in repository.", e);
        }
    }
}
