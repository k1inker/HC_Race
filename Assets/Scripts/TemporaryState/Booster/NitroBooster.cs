using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Nitro")]
public class NitroBooster : TemporaryBooster
{
    [SerializeField] private float _multiplier;
    public override void StartAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(_multiplier);
        base.StartAction();
    }
    public override void StopAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(-_multiplier);
        base.StopAction();
    }
}
