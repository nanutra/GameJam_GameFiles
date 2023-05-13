using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FolderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameFileFolderObject;

    [SerializeField]
    private Transform _fileSpawnTransform;

    [SerializeField]
    private CustomEvent _onGameFileOpenEvent;

    [SerializeField]
    private CustomEvent _onGameFileCloseEvent;

    [SerializeField]
    private List<PlayersFile> _allCurrentGameFilesInWindow;

    [SerializeField]
    private float _heightDifference = 100f;
    
    [SerializeField]
    private float _sideDifference = 100f;

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
        _allCurrentGameFilesInWindow = DataHandler._allCurrentFilesInOuindo;
        _gameFileFolderObject.SetActive(true);
        ShowFilesInWindow();
    }

    /// <summary>
    /// raised when play click on close cross
    /// </summary>
    public void OnGameFileClosed()
    {
        _gameFileFolderObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public void ShowFilesInWindow()
    {
        for(int i = 0; i < _allCurrentGameFilesInWindow.Count; i++)
        {
            _allCurrentGameFilesInWindow[i].transform.parent = null;
            _allCurrentGameFilesInWindow[i].transform.SetParent(_fileSpawnTransform.transform);

            Vector3 pos = _fileSpawnTransform.transform.position - Vector3.up * (i + 1) * _heightDifference;
            pos += Vector3.right * _sideDifference;
            _allCurrentGameFilesInWindow[i].transform.position = pos;

            _allCurrentGameFilesInWindow[i].SetTextPosition(true);
        }
    }
}
