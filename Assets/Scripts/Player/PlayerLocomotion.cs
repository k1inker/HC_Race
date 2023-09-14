using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerStats _stats;
    private BoxCollider2D _collider;

    private bool _isMoving;
    private int _horizontal = 0;
    private int _vertical = 0;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _stats = GetComponent<PlayerStats>();
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
        _horizontal = direction;
        if (direction == 0)
        {
            _isMoving = false;
            return;
        }
        _isMoving = true;
    }
    private void SetVerticalMove(int direction)
    {
        _vertical += direction;
        if (direction == 0)
        {
            _isMoving = false;
            _vertical = 0;
            return;
        }
        _isMoving = true;
    }
    private Vector2 CheckForBorders(Vector2 targetPosition)
    {
        if (Mathf.Abs(targetPosition.x) >= RoadManager.Instance.WidthBorder - (_collider.size.x / 2))
            targetPosition.x = transform.position.x;
        
        if(Mathf.Abs(targetPosition.y) >= RoadManager.Instance.HeightBorder - (_collider.size.y / 2))
            targetPosition.y = transform.position.y;

        return targetPosition;
    }
    private void FixedUpdate()
    {
        if (!_isMoving)
            return;

        Vector2 newPosition = transform.position + new Vector3(_horizontal * _stats.Speed, _vertical * _stats.Speed);
        transform.position = CheckForBorders(Vector2.Lerp(transform.position, newPosition, Time.deltaTime));
    }
}
