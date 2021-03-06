﻿using _03BarracksFactory.Contracts;

class ReportCommand:Command
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public ReportCommand(string[] data, IRepository repository) : base(data)
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
        string output = this.Repository.Statistics;
        return output;
    }
}
