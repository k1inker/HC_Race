using UnityEngine;

public class RoadManager : Singelton<RoadManager>
{
    [Header("Param road")]
    [SerializeField] private float speedRoad;
    [SerializeField] private float lineDestroy;
    [SerializeField] private float widthBorder;
    [SerializeField] private float heightBorder;

    [SerializeField] private GameObject moveableRoad;

    public float WidthBorder { get { return widthBorder / 2; } }
    public float HeightBorder { get { return heightBorder / 2; } }
    public float LineDestroy { get { return lineDestroy; } }
    public GameObject MoveableRoad { get { return moveableRoad; } }
    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(0, moveableRoad.transform.position.y - speedRoad, 0);
        moveableRoad.transform.position = Vector3.Lerp(moveableRoad.transform.position, newPosition, Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-widthBorder/2, heightBorder/2), new Vector3(widthBorder/2,heightBorder/2));
        Gizmos.DrawLine(new Vector3(widthBorder/2, heightBorder/2), new Vector3(widthBorder/2, -heightBorder/2));
        Gizmos.DrawLine(new Vector3(widthBorder/2, -heightBorder/2), new Vector3(-widthBorder/2,-heightBorder/2));
        Gizmos.DrawLine(new Vector3(-widthBorder/2, -heightBorder/2), new Vector3(-widthBorder/2, heightBorder/2));
    }
}
