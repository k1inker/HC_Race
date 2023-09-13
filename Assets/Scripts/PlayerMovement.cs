using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool isMoving;
    private int horizontal = 0;
    private int vertical = 0;

    private BoxCollider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        ManagerUI.Instance.OnHorizontalMovement += SetHorizontalMove;
        ManagerUI.Instance.OnVerticalMovement += SetVerticalMove;
    }
    private void OnDisable()
    {
        ManagerUI.Instance.OnHorizontalMovement -= SetHorizontalMove;
        ManagerUI.Instance.OnVerticalMovement -= SetVerticalMove;
    }
    private void SetHorizontalMove(int direction)
    {
        horizontal = direction;
        if (direction == 0)
        {
            isMoving = false;
            return;
        }
        isMoving = true;
    }
    private void SetVerticalMove(int direction)
    {
        vertical += direction;
        if (direction == 0)
        {
            isMoving = false;
            vertical = 0;
            return;
        }
        isMoving = true;
    }
    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        Vector2 newPosition = transform.position + new Vector3(horizontal * speed, vertical * speed);
        transform.position = CheckForBorders(Vector2.Lerp(transform.position, newPosition, Time.deltaTime));
    }
    private Vector2 CheckForBorders(Vector2 targetPosition)
    {
        if (Mathf.Abs(targetPosition.x) >= RoadManager.Instance.WidthBorder - (_collider.size.x / 2))
            targetPosition.x = transform.position.x;
        
        if(Mathf.Abs(targetPosition.y) >= RoadManager.Instance.HeightBorder - (_collider.size.y / 2))
            targetPosition.y = transform.position.y;

        return targetPosition;
    }
}
