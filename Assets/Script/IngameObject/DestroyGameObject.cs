using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public CustomEvent _event;

    public void OnEnable()
    {
        _event.myEvent += OnRaisedEvent;
    }

    private void OnDisable()
    {
        _event.myEvent -= OnRaisedEvent;
    }

    private void OnRaisedEvent()
    {
        Destroy(gameObject);
    }
}
