using UnityEngine;

public class HealthItem : MonoBehaviour, IPickable
{
    [SerializeField] private float _healthAmount;
    public void PickUp(StateManager player)
    {
        PlayerStats.Instance.RestoreHealth(_healthAmount);
        Destroy(gameObject);
    }
}
