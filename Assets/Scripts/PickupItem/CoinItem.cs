using DG.Tweening;
using UnityEngine;

public class CoinItem : MonoBehaviour, IPickable
{
    [SerializeField] private int amountScore;
    public void PickUp(StateManager player)
    {
        PlayerStats.Instance.IncreaseScore(amountScore);
        // if coin pick by magnet
        if(player == null)
            PathToPlayer();
        else
            Destroy(gameObject);
    }
    private void PathToPlayer()
    {
        GetComponent<Collider2D>().enabled = false;
        DOTween.Sequence()
            .Append(transform.DOMove(PlayerStats.Instance.transform.position, 0.5f))
            .Join(transform.DOScale(new Vector3(0, 0, 0), 0.5f))
            .AppendCallback(() => Destroy(gameObject));
    }
}
