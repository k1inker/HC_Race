using UnityEngine;

public class DestroyAbroadObject : MonoBehaviour
{
    private float _lineDestroy;
    private void OnEnable()
    {
        _lineDestroy = RoadManager.Instance.LineDestroy;
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y) > _lineDestroy)
            Destroy(gameObject);
    }
}
