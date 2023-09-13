using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private float previousPosition;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x > transform.position.x && previousPosition < transform.position.x)
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(1);
            previousPosition = eventData.position.x;
        }
        else if (eventData.position.x < transform.position.x && previousPosition > transform.position.x)
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(-1);
            previousPosition = eventData.position.x;
        }
        else if(eventData.position.x == transform.position.x && previousPosition == transform.position.x)
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(0);
            previousPosition = eventData.position.x;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.position.x > transform.position.x)
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(1);
        }
        else if(eventData.position.x < transform.position.x)
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(-1);
        }
        else
        {
            ManagerUI.Instance.OnHorizontalMovement?.Invoke(0);
        }
        previousPosition = eventData.position.x;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ManagerUI.Instance.OnHorizontalMovement?.Invoke(0);
        previousPosition = 0;
    }
}
