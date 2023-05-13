using UnityEngine;

public class ClickableObject : MonoBehaviour, IPointableObject
{
    private void Awake()
    {
        InputManagerHandlerData.OnClick += InputManagerHandlerData_OnClick;
    }

    private void OnDestroy()
    {
        InputManagerHandlerData.OnClick -= InputManagerHandlerData_OnClick;
    }

    private void InputManagerHandlerData_OnClick(Vector2 obj)
    {
       
    }

    public void OnClicked()
    {

    }

    public void OnMouseDrag()
    {
        transform.position = new Vector3(InputManagerHandlerData._lastPos.x, InputManagerHandlerData._lastPos.y, 0f);
    }
}
    
