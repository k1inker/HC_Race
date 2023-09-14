using UnityEngine;

public abstract class TemporaryState : ScriptableObject
{
    public float duration;
    public abstract void StartAction();
    public abstract void UpdateAction(ref float time);
    public abstract void StopAction();
}
