using UnityEngine;

public class DamageObstacles : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _isDeadly;
    public void DealDamage()
    {
        PlayerStats.Instance.TakeDamage(_damage, _isDeadly);
        Destroy(gameObject);
    }
}
