using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;

/// <summary>
/// 数据表管理器
/// </summary>
public class DataTableManager
{
    public Dictionary<int, TownInfo> TownTable;

    public void LoadTownTable(List<TownInfo> rawTownTable)
    {
        TownTable = new Dictionary<int, TownInfo>();
        for (int i = 0; i < rawTownTable.Count; i++)
        {
            var id = rawTownTable[i].ID;
            if (TownTable.ContainsKey(id))
            {
                Debug.LogErrorFormat("{0} has duplicate keys!", "TownTable", id);
            }
            TownTable.Add(id, rawTownTable[i]);
        }
    }

    public FleetInfo FleetInfo;


    public Dictionary<int, CommodityInfo> CommodityTable;

    public void LoadCommodityTable(List<CommodityInfo> rawTable)
    {
        CommodityTable = new Dictionary<int, CommodityInfo>();
        for (int i = 0; i < rawTable.Count; i++)
        {
            var id = rawTable[i].ID;
            if (CommodityTable.ContainsKey(id))
            {
                Debug.LogErrorFormat("{0} has duplicate keys!", "CommodityTable", id);
            }
            CommodityTable.Add(id, rawTable[i]);
        }
    }
}