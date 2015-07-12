using System.Collections.Generic;
using Assets.Scripts.Data;
using Fairwood.Math;
using UnityEngine;

/// <summary>
/// 地图
/// </summary>
public class Map : MonoBehaviour
{
    public GameObject TownButtonPrefab;
    public Transform Container;
    public List<TownButton> TownButtonList;

    public void Setup(List<Town> visibleTowns)
    {
        Clear();
        if (null == TownButtonList) TownButtonList = new List<TownButton>();
        for (int i = 0; i < visibleTowns.Count; i++)
        {
            var town = visibleTowns[i];
            var townButton = PrefabHelper.InstantiateAndReset<TownButton>(TownButtonPrefab, Container);
            TownButtonList.Add(townButton);
            townButton.Model = town;
            townButton.Setup();
            townButton.transform.localPosition = LogicPositionToMapPosition(town.Info.Position);
        }
    }

    public void Clear()
    {
        if (null != TownButtonList)
        {
            for (int i = 0; i < TownButtonList.Count; i++)
            {
                Destroy(TownButtonList[i].gameObject);
            }
            TownButtonList.Clear();
        }
    }

    public Vector2 MapPositionToLogicPosition(Vector2 mapPos)
    {
        return mapPos / 0.01f;
    }
    public Vector2 LogicPositionToMapPosition(Vector2 logicPos)
    {
        return logicPos*0.01f;
    }
}