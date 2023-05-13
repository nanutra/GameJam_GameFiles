using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameFileFolderObject;

    [SerializeField]
    private CustomEvent _onGameFileOpenEvent;

    private void OnEnable()
    {
        _onGameFileOpenEvent.myEvent += OnGameFileOpen;
    }

    private void OnDisable()
    {
        _onGameFileOpenEvent.myEvent -= OnGameFileOpen;
    }

    public void OnGameFileOpen()
    {
        _gameFileFolderObject.SetActive(true);
    }

    public void OnGameFileClosed()
    {
        _gameFileFolderObject.SetActive(false);
    }
}
