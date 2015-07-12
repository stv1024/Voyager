using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;

public static class TestData
{
    public static List<TownInfo> TownInfoTable=new List<TownInfo>
    {
        new TownInfo
        {
            ID = 1,
            Name = "KingsLanding",
            Position = new Vector2(318, -61)
        },
        new TownInfo
        {
            ID = 2,
            Name = "WinterFell",
            Position = new Vector2(-391, 103)
        },
        new TownInfo
        {
            ID = 3,
            Name = "Eyrie",
            Position = new Vector2(225, 293)
        },
    };

    //public static List<int> VisibleTownIDs = new List<int>{1, 2, 3};

    public static FleetInfo Fleet = new FleetInfo
    {
        ID = 1,
        Name = "Fearless",
        OriginalSpeed = 200,
    };

    public static List<CommodityInfo> CommodityTable = new List<CommodityInfo>
    {
        new CommodityInfo
        {
            ID = 1,
            Name = "Fish",
            Value = 60,
            ConsumePerPopulationPerMinute = 0.01,
        }
    };

    public static SavesStructure Saves = new SavesStructure
    {
        TownList = new List<SavesStructure.Town>
        {
            new SavesStructure.Town
            {
                ID = 1,
                Population = 1200,
                CommodityAmountTable = new Dictionary<int, long>
                {
                    {1, 124}
                }
            },
            new SavesStructure.Town
            {
                ID = 2,
                Population = 1400,
                CommodityAmountTable = new Dictionary<int, long>
                {
                    {1, 102}
                }
            },
            new SavesStructure.Town
            {
                ID = 3,
                Population = 1600,
                CommodityAmountTable = new Dictionary<int, long>
                {
                    {1, 167}
                }
            },
        }
    };
}