using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Magnet")]
public class MagnetBooster : TemporaryBooster
{
    [SerializeField] private float _radius;
    [SerializeField] private GameObject _magnet;
    public override void StartAction()
    {
        Instantiate(_magnet, PlayerStats.Instance.transform);
        _magnet.GetComponent<CircleCollider2D>().radius = _radius;
        ManagerUI.Instance.SetupBooster(this);
    }
    public override void StopAction()
    {
        ManagerUI.Instance.DisableBooster();
        Destroy(_magnet);
    }

    public override void UpdateAction(ref float time)
    {
        time -= Time.fixedDeltaTime;
        ManagerUI.Instance.SetBooster(time);
    }
}
