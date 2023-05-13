using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = this.transform.position;
    }

    private void OnEnable()
    {
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ClickableObject clickable) && DataHandler._clickedObject != null && DataHandler._clickedObject == this)
        {
            DataHandler._targetFromClickedObject = clickable;
        }
    }

    //drag
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = transform.position;
        DataHandler._clickedObject = this;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(InputManagerHandlerData._lastPos.x, InputManagerHandlerData._lastPos.y, 0f);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _startPosition;
    }
}
    
