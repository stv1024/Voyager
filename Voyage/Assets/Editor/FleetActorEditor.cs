using UnityEditor;

[CustomEditor(typeof (FleetActor))]
public class FleetActorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var fleetActor = target as FleetActor;
        DrawDefaultInspector();

        if (fleetActor != null)
        {
            var fleet = fleetActor.Model;
            if (null != fleet)
            {
                EditorGUILayout.LabelField("ID", fleet.ID.ToString());
                EditorGUILayout.LabelField("Name", fleet.Name);
                EditorGUILayout.LabelField("LastUpdateRealTime", fleet.LastUpdateRealTime.ToString());
                EditorGUILayout.LabelField("State", fleet.State.ToString());
                EditorGUILayout.LabelField("Dest.Pos", fleet.DestinationPosition.ToString());
                EditorGUILayout.LabelField("Dest.Town", fleet.DestinationTown == null ? "null" : fleet.DestinationTown.Name);
            }
            else
            {
                EditorGUILayout.LabelField("No Fleet Assigned");
            }
            EditorUtility.SetDirty(target);
        }
    }
}