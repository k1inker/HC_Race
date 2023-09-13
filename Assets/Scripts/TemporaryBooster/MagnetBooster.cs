using UnityEngine;

public class MagnetBooster : TemporaryBooster
{
    [SerializeField] private float _radius;
    public override void StartAction(PowerUpManager powerUpManager)
    {

        ManagerUI.Instance.SetupBooster(this);
    }

    public override void StopAction(PowerUpManager powerUpManager)
    {
        ManagerUI.Instance.DisableBooster();
    }
}
