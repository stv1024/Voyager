using System.Linq;
using UnityEditor;

[CustomEditor(typeof(TownButton))]
public class TownButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var townActor = target as TownButton;
        DrawDefaultInspector();

        if (townActor != null)
        {
            var town = townActor.Model;
            if (null != town)
            {
                EditorGUILayout.LabelField("ID", town.ID.ToString());
                EditorGUILayout.LabelField("Name", town.Name);
                EditorGUILayout.LabelField("LastUpdateRealTime", town.LastUpdateRealTime.ToString());
                EditorGUILayout.LabelField("Population", town.Population.ToString());
                EditorGUILayout.LabelField("CommodityAmountTable-----");
                foreach (var kv in town.CommodityAmountTable)
                {
                    var commodityInfo = MainController.Instance.DataTableManager.CommodityTable[kv.Key];
                    EditorGUILayout.LabelField(string.Format("[{0}]{1}", commodityInfo.ID, commodityInfo.Name), kv.Value.ToString());
                }
                EditorGUILayout.LabelField("CommodityPriceTable-----");
                foreach (var kv in town.CommodityPriceTable)
                {
                    var commodityInfo = MainController.Instance.DataTableManager.CommodityTable[kv.Key];
                    EditorGUILayout.LabelField(string.Format("[{0}]{1}", commodityInfo.ID, commodityInfo.Name), kv.Value.ToString());
                }
                EditorGUILayout.LabelField("ProductivityTable-----");
                foreach (var kv in town.ProductivityTable.Where(x=>x.Value > 0))
                {
                    var commodityInfo = MainController.Instance.DataTableManager.CommodityTable[kv.Key];
                    EditorGUILayout.LabelField(string.Format("[{0}]{1}", commodityInfo.ID, commodityInfo.Name), kv.Value.ToString());
                }
                //EditorGUILayout.LabelField("Dest.Pos", town.DestinationPosition.ToString());
                //EditorGUILayout.LabelField("Dest.Town", town.DestinationTown == null ? "null" : town.DestinationTown.Name);
            }
            else
            {
                EditorGUILayout.LabelField("No Fleet Assigned");
            }
            EditorUtility.SetDirty(target);
        }
    }
}