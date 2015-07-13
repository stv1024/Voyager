using System;
using Assets.Scripts.Data;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fleet : Entity
{
    public FleetInfo Info;
    public int ID { get { return Info.ID; } }
    public string Name { get { return Info.Name; } }

    public struct AttribsStruct
    {
        public float Speed;
    }

    public AttribsStruct Attribs;

    public enum StateEnum
    {
        /// <summary>
        /// 航行中，一定有目的地信息
        /// </summary>
        Sailing,
        /// <summary>
        /// 停泊，目的地信息无用
        /// </summary>
        Anchored,
    }

    public StateEnum State;

    public Vector2 Position;
    public Vector2 Velocity;
    public Town AnchoredTown;

    public Vector2 DestinationPosition;
    public Town DestinationTown;

    public readonly Dictionary<int, double> CommodityAmountTable = new Dictionary<int, double>();

    public FleetActor Actor;

    public void Reset()
    {
        State = StateEnum.Anchored;
        Velocity = Vector2.zero;
        DestinationTown = null;
        foreach (var commodityInfo in MainController.Instance.DataTableManager.CommodityTable.Values)
        {
            var id = commodityInfo.ID;
            if (!CommodityAmountTable.ContainsKey(id))
            {
                CommodityAmountTable.Add(id, 0);
            }
        }
        Rebuild();
    }

    public void SetDestination(Vector2 position)
    {
        State = StateEnum.Sailing;
        AnchoredTown = null;
        DestinationPosition = position;
        DestinationTown = null;
    }
    public void SetDestination(Town town)
    {
        State = StateEnum.Sailing;
        AnchoredTown = null;
        DestinationTown = town;
        DestinationPosition = town.Info.Position;
    }

    void AnchorToDestination()
    {
        if (State != StateEnum.Sailing)
        {
            Debug.LogErrorFormat("Want to anchor but State is not Sailing! Name:[{0}]{1], Pos:{2}", ID, Name, Position);
            return;
        }
        State = StateEnum.Anchored;
        AnchoredTown = DestinationTown;
        if (null != AnchoredTown) Debug.LogFormat("Anchor to Town:[{0}]{1}", AnchoredTown.ID, AnchoredTown.Name);
        else Debug.LogFormat("Anchor to Position:{0}", Position);
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        switch (State)
        {
            case StateEnum.Sailing:
                var destinationVector = DestinationPosition - Position;
                Velocity = destinationVector.normalized*Attribs.Speed;
                var stepVector = Velocity*dt;
                if (stepVector.magnitude >= destinationVector.magnitude)
                {
                    Velocity = Vector2.zero;
                    Position = Position + destinationVector;
                    AnchorToDestination();
                }
                else
                {
                    Position = Position + stepVector;
                }
                break;
            case StateEnum.Anchored:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public void BuyCommodityFromTown(Town town, int id)
    {
        //TODO:检测
        CommodityAmountTable[id] += 1;
        MainController.Instance.Golds -= town.CommodityPriceTable[id];
        town.OnFleetBuyCommodity(id);
    }
    public void SellCommodityToTown(Town town, int id)
    {
        //TODO:检测
        CommodityAmountTable[id] -= 1;
        MainController.Instance.Golds += town.CommodityPriceTable[id];
        town.OnFleetSellCommodity(id);
    }

    public void Rebuild()
    {
        Attribs.Speed = Info.OriginalSpeed;
    }

}
