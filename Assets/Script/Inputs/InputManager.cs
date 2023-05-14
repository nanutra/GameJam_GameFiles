using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 _lastPos;

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
}
