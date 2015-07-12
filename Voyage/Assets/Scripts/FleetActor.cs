using UnityEngine;

/// <summary>
/// 舰队表现层
/// </summary>
public class FleetActor : BaseActor
{
    public Fleet Model;
    public Vector2 Position;
    public Vector2 Velocity;

    protected override void Update()
    {
        base.Update();
        if (null == Model) return;
        Position = Model.Position;
        Velocity = Model.Velocity;
        Position += Velocity*(LastUpdateRealTime - Model.LastUpdateRealTime);
        transform.localPosition = MainController.Instance.Map.LogicPositionToMapPosition(Position);
        transform.right = Velocity;
    }
}