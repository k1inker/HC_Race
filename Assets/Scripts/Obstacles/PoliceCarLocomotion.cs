using UnityEngine;

public class PoliceCarLocomotion : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + _speed, 0);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }
}
