using UnityEngine;

public class ClickableObject : MonoBehaviour, IDragableUiObject, IClickableUiObject
{
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = this.transform.position;
    }

    public void OnDragItem()
    {
        transform.position = new Vector3(InputManagerHandlerData._lastPos.x, InputManagerHandlerData._lastPos.y, 0f);
    }

    public void OnBegginDragItem()
    {
        _startPosition = transform.position;
    }

    public void OnEndDragItem()
    {
        transform.position = _startPosition;
    }

    public void OnClick()
    {
        
    }
}
    
