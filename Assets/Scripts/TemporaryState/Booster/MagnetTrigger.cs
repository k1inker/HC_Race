using UnityEngine;

public class MagnetTrigger : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _circleCollider;
    public void SetRadius(float radius)
    {
        _circleCollider.radius = radius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out CoinItem coin))
            return;

        Debug.Log(coin);

        coin.PickUp(null);
    }
}
