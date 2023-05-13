using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Vector3 _startPosition;
    private int _clickCount = 0;

    private void Awake()
    {
        _startPosition = this.transform.position;
    }

    public virtual void OnEnable()
    {

    }

    public virtual void OnDisable()
    {

    }

    public virtual void Update()
    {
        if(Input.GetMouseButtonUp(0) && DataHandler._clickedObject == this) 
        {
            Debug.Log("mouse up going do ondrop");
            OnDrop();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ClickableObject clickable) && DataHandler._clickedObject == this)
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

    public virtual void OnDrop() { }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

        _clickCount++;
        if(_clickCount >= 2)
        {
            ClickCount();
        }
    }
    public virtual void ClickCount()
    {

    }

}
    
