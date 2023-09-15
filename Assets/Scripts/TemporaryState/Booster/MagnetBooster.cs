using UnityEngine;

[CreateAssetMenu(menuName = "TemporaryState/Booster/Magnet")]
public class MagnetBooster : TemporaryBooster
{
    [SerializeField] private float _radius;
    [SerializeField] private MagnetTrigger _magnet;

    private GameObject _refObject;
    public override void StartAction()
    {
        _refObject = Instantiate(_magnet.gameObject, PlayerStats.Instance.gameObject.transform);
        _magnet.SetRadius(_radius);
        base.StartAction();
    }
    public override void StopAction()
    {
        Destroy(_refObject);
        base.StopAction();
    }
}
