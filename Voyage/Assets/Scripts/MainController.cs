using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 最高级控制器，主入口
/// </summary>
public class MainController : MonoBehaviour
{
    public static MainController Instance { get; private set; }

    public DataTableManager DataTableManager;
    public GameDataManager GameDataManager;

    public Map Map;

    public Fleet FocusedFleet;
    public List<Entity> EntityList;

    public float CurrentTickRealTime;
    public float WorldTime;
    public float RealTimeToWorldTime = 1;
    public float TickCountDown = 0.05f;
    public float TickCountDownRemaining;

    public float CurrentTownSettleSeconds;

    public double Golds = 1000;
    public Text GoldsLabel;

    public void Awake()
    {
        Instance = this;

        DataTableManager = new DataTableManager();
        DataTableManager.LoadTownTable(TestData.TownInfoTable);
        DataTableManager.FleetInfo = TestData.Fleet;
        DataTableManager.LoadCommodityTable(TestData.CommodityTable);
        var save = TestData.Saves;

        EntityList = new List<Entity>();

        //创建城镇
        GameDataManager = new GameObject("GameDataManager").AddComponent<GameDataManager>();
        GameDataManager.TownList = new List<Town>();
        foreach (var townInfo in DataTableManager.TownTable.Values)
        {
            var town = new Town();
            town.Info = townInfo;
            var townSave = save.TownList.Find(x => x.ID == townInfo.ID);
            if (null != townSave)
            {
                town.LoadSave(townSave);
            }
            GameDataManager.TownList.Add(town);
            EntityList.Add(town);
            town.Reset();
        }

        Map.Setup(GameDataManager.TownList);

        //创建舰队
        var fleet = new Fleet();
        fleet.Info = DataTableManager.FleetInfo;
        fleet.Position = new Vector2(0, 0);
        fleet.Actor = Map.transform.Find("Fleet").GetComponent<FleetActor>();
        fleet.Actor.Model = fleet;
        fleet.Reset();
        EntityList.Add(fleet);
        FocusedFleet = fleet;

        WorldTime = 0;
        TickCountDownRemaining = 0;
        //CurrentTownSettleSeconds = -1;
    }

    void Update()
    {
        TickCountDownRemaining -= Time.deltaTime;
        if (TickCountDownRemaining <= 0)
        {
            TickCountDownRemaining += TickCountDown;
            Tick();
        }
    }

    void Tick()
    {
        var worldDt = (Time.realtimeSinceStartup - CurrentTickRealTime)*RealTimeToWorldTime;
        WorldTime += worldDt;
        CurrentTickRealTime = Time.realtimeSinceStartup;

        foreach (var entity in EntityList)
        {
            entity.Update(worldDt);
        }

        if (GoldsLabel) GoldsLabel.text = string.Format("{0:0}○", Golds);
        if (TradePanel.Instance && TradePanel.Instance.isActiveAndEnabled)
        {
            TradePanel.Instance.Refresh();
        }
    }

    public void SendFocusedFleetToTown(Town town)
    {
        Debug.LogFormat("SendFocusedFleetToTown:{0}", town);
        FocusedFleet.SetDestination(town);
    }
    public void SendFocusedFleetToPosition(Vector2 position)
    {
        Debug.LogFormat("SendFocusedFleetToPosition:{0}", position);
        FocusedFleet.SetDestination(position);
    }
}