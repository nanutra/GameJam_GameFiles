using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameFileFolderObject;

    public void OnGameFileOpen()
    {
        _gameFileFolderObject.SetActive(true);
    }

    public void OnGameFileClosed()
    {
        _gameFileFolderObject.SetActive(false);
    }
}
