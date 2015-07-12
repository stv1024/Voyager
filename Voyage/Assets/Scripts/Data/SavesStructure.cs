using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// 存档结构
    /// </summary>
    public class SavesStructure
    {
        public class Town
        {
            public int ID;
            public long Population;
            public Dictionary<int, long> CommodityAmountTable;
        }

        public List<Town> TownList;
    }
}