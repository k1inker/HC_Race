using UnityEngine;

public class TemporaryItem : MonoBehaviour, IPickable
{
    [SerializeField] private TemporaryState _booster;
    public void PickUp(StateManager player)
    {
        player.TakeState(_booster);
        Destroy(gameObject);
    }
}
