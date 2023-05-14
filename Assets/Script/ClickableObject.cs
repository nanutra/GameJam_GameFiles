using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Vector3 _startPosition;
    protected int _clickCount = 0;
    [SerializeField] private bool _canBeClicked = false;

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
            OnDrop();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(DataHandler._clickedObject != this)
        {
            DataHandler._targetFromClickedObject = this;
        }
        /*
        if (collision.TryGetComponent(out ClickableObject clickable) && DataHandler._clickedObject == this)
        {
            DataHandler._targetFromClickedObject = clickable;
        }
        /**/
    }

    //drag
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = transform.position;
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

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (DataHandler._clickedObject != this)
        {
            DataHandler._targetFromClickedObject = this;
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (DataHandler._clickedObject == this)
        {
            DataHandler._targetFromClickedObject = null;
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            DataHandler._clickedObject = this;
            if (!_canBeClicked) return;
            _clickCount++;
            if (_clickCount >= 2)
            {
                ClickCount();
                _clickCount = 0;
            }
        }
       
    }
    public virtual void ClickCount()
    {

    }

}
    
