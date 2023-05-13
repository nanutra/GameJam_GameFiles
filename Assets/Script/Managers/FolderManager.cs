using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameFileFolderObject;

    [SerializeField]
    private GameObject _gameWindowObject;

    [SerializeField]
    private CustomEvent _onGameFileOpenEvent;

    [SerializeField]
    private CustomEvent _onGameFileCloseEvent;

    private void OnEnable()
    {
        _onGameFileOpenEvent.myEvent += OnGameFileOpen;
        _onGameFileCloseEvent.myEvent += OnGameFileClosed;
    }

    private void OnDisable()
    {
        _onGameFileOpenEvent.myEvent -= OnGameFileOpen;
        _onGameFileCloseEvent.myEvent -= OnGameFileClosed;
    }

    /// <summary>
    /// raised when double click on game file
    /// </summary>
    public void OnGameFileOpen()
    {
        _gameFileFolderObject.SetActive(true);
    }

    /// <summary>
    /// raised when play click on close cross
    /// </summary>
    public void OnGameFileClosed()
    {
        _gameFileFolderObject.SetActive(false);
    }
}
