using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Debuff/Oil")]
public class DecelerationDebuff : TemporaryState
{
    [SerializeField] private float _multiplierSlow;
    public override void StartAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(-_multiplierSlow);
    }

    public override void StopAction()
    {
        PlayerStats.Instance.AddSpeedMultiplier(_multiplierSlow);
    }

    public override void UpdateAction(ref float time)
    {
        time -= Time.fixedDeltaTime;
    }
}
