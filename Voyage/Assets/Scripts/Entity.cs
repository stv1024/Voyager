public abstract class Entity
{
    public float LastUpdateRealTime;

    public virtual void Update(float dt)
    {
        LastUpdateRealTime = MainController.Instance.CurrentTickRealTime;
    }
}