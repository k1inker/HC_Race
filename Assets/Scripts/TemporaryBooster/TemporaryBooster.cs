using UnityEngine;

public abstract class TemporaryBooster : ScriptableObject
{
    public float duration;

    [Header("For UI Slider")]
    public string nameBooster;
    public Sprite imgSlider;
    public Sprite backgroundSlider;

    public abstract void StartAction(PowerUpManager powerUpManager);
    public abstract void StopAction(PowerUpManager powerUpManager);
}
