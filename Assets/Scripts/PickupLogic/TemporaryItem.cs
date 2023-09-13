using UnityEngine;

public class TemporaryItem : MonoBehaviour, IPickable
{
    [SerializeField] private TemporaryBooster _booster;
    public void PickUp(PowerUpManager player)
    {
        player.TakeBooster(_booster);
        Destroy(gameObject);
    }
}
