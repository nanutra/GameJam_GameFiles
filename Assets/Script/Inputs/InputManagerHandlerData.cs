using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManagerHandlerData
{
    public static Vector2 _lastPos;

    public static event Action<Vector2> OnClick;
    public static void Click(this InputManager inputManager, Vector2 _pos) => OnClick?.Invoke(_pos);
}
