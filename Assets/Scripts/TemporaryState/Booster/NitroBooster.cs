using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Nitro")]
public class NitroBooster : TemporaryBooster
{
    [SerializeField] private float _multiplier;
    public override void StartAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(_multiplier);
        ManagerUI.Instance.SetupBooster(this);
    }
    public override void StopAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(-_multiplier);
        ManagerUI.Instance.DisableBooster();
    }

    public override void UpdateAction(ref float time)
    {
        time -= Time.fixedDeltaTime;
        ManagerUI.Instance.SetBooster(time);
    }
}
