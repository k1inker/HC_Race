using DG.Tweening;
using UnityEngine;

public class CoinItem : MonoBehaviour, IPickable
{
    [SerializeField] private int amountScore;
    public void PickUp(StateManager player)
    {
        PlayerStats.Instance.IncreaseScore(amountScore);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Contains("Magnet"))
            return;

        GetComponent<Collider2D>().enabled = false;
        PathToPlayer();
    }
    private void PathToPlayer()
    {
        DOTween.Sequence()
            .Append(transform.DOMove(PlayerStats.Instance.transform.position, 0.5f))
            .Join(transform.DOScale(new Vector3(0, 0, 0), 0.5f))
            .AppendCallback(() => Destroy(gameObject));
    }
}
