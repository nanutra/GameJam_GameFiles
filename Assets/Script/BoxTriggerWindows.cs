using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerWindows : MonoBehaviour
{
    public GameObject go;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger la mere a qui la ");
        go.SetActive(true);
    }
}
