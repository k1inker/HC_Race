using UnityEngine;

[CreateAssetMenu(menuName = "Booster/Nitro")]
public class NitroBooster : TemporaryBooster
{
    [SerializeField] private float _multiplier;
    public override void StartAction(PowerUpManager powerUpManager)
    {
        powerUpManager.playerLocomotion.SetMultiplierSpeed(_multiplier);
        ManagerUI.Instance.SetupBooster(this);
    }
    public override void StopAction(PowerUpManager powerUpManager)
    {
        powerUpManager.playerLocomotion.SetMultiplierSpeed(1);
        ManagerUI.Instance.DisableBooster();
    }
}
