using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 _lastPos;

    private string _valuesText;

    public TestInputActions _actions;

    private void OnClick(InputValue value)
    {
        this.Click(_lastPos);
    }

    private void OnMousePos(InputValue value)
    {
        _lastPos = value.Get<Vector2>();
        InputManagerHandlerData._lastPos = _lastPos;
    }

    private void OnGUI()
    {
        _valuesText = DataHandler._clickedObject + " " + DataHandler._targetFromClickedObject;
        GUI.Label(new Rect(100, 20, 300, 20), _valuesText);
    }
}
