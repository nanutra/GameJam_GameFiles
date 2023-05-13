using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    CustomEvent m_OnPauseEvent;
    [SerializeField]
    GameObject[] m_gameObjectsToDisplay;

    private void OnEnable()
    {
        m_OnPauseEvent.myEvent += OnPause;
    }
    private void OnDisable()
    {
        m_OnPauseEvent.myEvent -= OnPause;
    }

    void OnPause()
    {
        foreach (GameObject go in m_gameObjectsToDisplay)
        { 
            go.SetActive(DataHandler.IsGamePause); 
        }

    }

}
