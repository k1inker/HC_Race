using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Shield")]
public class ShieldBooster : TemporaryBooster
{
    public override void StartAction()
    {
        PlayerStats.Instance.SetInvulnerable(true);
        base.StartAction();
    }

    public override void StopAction()
    {
        PlayerStats.Instance.SetInvulnerable(false);
        base.StopAction();
    }
}
