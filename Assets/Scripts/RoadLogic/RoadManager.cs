using UnityEngine;

public class RoadManager : Singelton<RoadManager>
{
    [Header("Param road")]
    [SerializeField] private float _speedRoad;
    [SerializeField] private float _lineDestroy;
    [SerializeField] private float _widthBorder;
    [SerializeField] private float _heightBorder;

    [SerializeField] private GameObject moveableRoad;

    public float WidthBorder { get { return _widthBorder / 2; } }
    public float HeightBorder { get { return _heightBorder / 2; } }
    public float LineDestroy { get { return _lineDestroy; } }
    public GameObject MoveableRoad { get { return moveableRoad; } }
    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(0, moveableRoad.transform.position.y - _speedRoad, 0);
        moveableRoad.transform.position = Vector3.Lerp(moveableRoad.transform.position, newPosition, Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-_widthBorder/2, _heightBorder/2), new Vector3(_widthBorder/2,_heightBorder/2));
        Gizmos.DrawLine(new Vector3(_widthBorder/2, _heightBorder/2), new Vector3(_widthBorder/2, -_heightBorder/2));
        Gizmos.DrawLine(new Vector3(_widthBorder/2, -_heightBorder/2), new Vector3(-_widthBorder/2,-_heightBorder/2));
        Gizmos.DrawLine(new Vector3(-_widthBorder/2, -_heightBorder/2), new Vector3(-_widthBorder/2, _heightBorder/2));
    }
    private void OnEnable()
    {
        PlayerStats.Instance.OnDeath += StopRoad;
    }
    private void OnDisable()
    {
        PlayerStats.Instance.OnDeath -= StopRoad;
    }
    private void StopRoad()
    {
        _speedRoad = 0;
    }
}
