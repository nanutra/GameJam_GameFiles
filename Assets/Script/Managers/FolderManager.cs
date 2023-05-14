using System.Collections.Generic;
using UnityEngine;

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
    private CustomEvent _onFolderSelected;

    [SerializeField]
    private List<PlayersFile> _allCurrentGameFilesInWindow;
    [SerializeField]
    public List<PlayersFolder> _allWindowFolder;
    public GameObject _folderWindow;

    [SerializeField]
    private float _heightDifference = 100f;
    
    [SerializeField]
    private float _sideDifference = 100f;

    private void OnEnable()
    {
        _onGameFileOpenEvent.myEvent += OnGameFileOpen;
        _onGameFileCloseEvent.myEvent += OnGameFileClosed;
        _onFolderSelected.myEvent += OnFolderSelected;
    }

    private void OnDisable()
    {
        _onGameFileOpenEvent.myEvent -= OnGameFileOpen;
        _onGameFileCloseEvent.myEvent -= OnGameFileClosed;
        _onFolderSelected.myEvent -= OnFolderSelected;
    }

    private void Awake()
    {
        DataHandler._allWindowFolder = _allWindowFolder;
        DataHandler.FileWindow = _folderWindow;
    }
    /// <summary>
    /// raised when double click on game file
    /// </summary>
    public void OnGameFileOpen()
    {
        _allCurrentGameFilesInWindow = DataHandler._allCurrentFilesInOuindo;
        _gameFileFolderObject.SetActive(true);
    }

    /// <summary>
    /// raised when play click on close cross
    /// </summary>
    public void OnGameFileClosed()
    {
        _gameFileFolderObject.SetActive(false);
    }

    public void OnFolderSelected()
    {
 
        /*
        Debug.Log("doubleClick");
        List<PlayersFolder> tempList = DataHandler._allPlayersFolder;
        tempList.Remove(DataHandler._currentFolderSelected);

        DataHandler._currentFolderSelected.DisableOrEnableControllers(true);
        foreach(var temp in tempList)
        {
            temp.DisableOrEnableControllers(false);
        }
        /**/
    }

}
