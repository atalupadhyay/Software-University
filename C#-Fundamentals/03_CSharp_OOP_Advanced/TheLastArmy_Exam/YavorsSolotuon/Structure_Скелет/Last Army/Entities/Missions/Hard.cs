﻿public class Hard : Mission
{
    private const string NameConst = "Disposal of terrorists";
    private const double EnduranceRequiredConst = 80;
    private const double WearLevelDecrementConst = 70;

    public Hard(double scoreToComplite) : base(scoreToComplite)
    {
    }

    public override string Name => NameConst;
    public override double EnduranceRequired => EnduranceRequiredConst;
    public override double WearLevelDecrement => WearLevelDecrementConst;
}
