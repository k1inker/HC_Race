using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Shield")]
public class ShieldBooster : TemporaryBooster
{
    public override void StartAction()
    {
        PlayerStats.Instance.SetInvulnerable(true);
        ManagerUI.Instance.SetupBooster(this);
    }

    public override void StopAction()
    {
        PlayerStats.Instance.SetInvulnerable(false);
        ManagerUI.Instance.DisableBooster();
    }

    public override void UpdateAction(ref float time)
    {
        time -= Time.fixedDeltaTime;
        ManagerUI.Instance.SetBooster(time);
    }
}
