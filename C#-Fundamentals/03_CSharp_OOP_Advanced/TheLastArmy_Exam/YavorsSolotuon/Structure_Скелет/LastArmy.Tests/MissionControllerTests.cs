﻿
using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wereHouse = new WareHouse();
        var missionController = new MissionController(army, wereHouse);

        var mission = new Easy(1);
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined"));
    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wereHouse = new WareHouse();
        var missionController = new MissionController(army, wereHouse);

        var mission = new Easy(0);
        string result = missionController.PerformMission(mission);


        Assert.IsTrue(result.StartsWith("Mission completed"));
    }
}

