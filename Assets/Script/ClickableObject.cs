using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerDownHandler, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;
    public enum TypeObject
    {
        None,
        File,
        Folder
    }

    public TypeObject UiObjectType;

    private void Awake()
    {
        _startPosition = this.transform.position;
    }

    public void OnEndDragItem()
    {
        transform.position = _startPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.TryGetComponent(out ClickableObject clickable) && DataHandler._clickedObject != null && DataHandler._clickedObject == this)
        {
            DataHandler._targetFromClickedObject = clickable;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DataHandler._clickedObject = this;
        Debug.Log(DataHandler._clickedObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(DataHandler._targetFromClickedObject);
        DataHandler._clickedObject.gameObject.SetActive(false);
    }


    //drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(InputManagerHandlerData._lastPos.x, InputManagerHandlerData._lastPos.y, 0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _startPosition;
    }
}
    
