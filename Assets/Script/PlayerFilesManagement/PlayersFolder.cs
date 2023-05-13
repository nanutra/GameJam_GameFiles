using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayersFolder : ClickableObject
{
    [SerializeField]
    private Transform _parentFiles;

    public Transform ParentFiles => _parentFiles;

    [SerializeField]
    private TextMeshProUGUI _fileNameTextReference = null;

    [SerializeField]
    private string _fileName;

    [SerializeField]
    private List<PlayersFile> _controllers = new();

    [SerializeField]
    private float _heightDifference = 70;
    private float _sidetDifference = 0;

    [SerializeField]
    private CustomEvent _onFolderSelected;

    [SerializeField]
    private bool _isMenuFolder = false;

    public override void OnEnable()
    {
        base.OnEnable();
        PlayersFile.onFileMove += OnFileMoved;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PlayersFile.onFileMove -= OnFileMoved;
    }

    private void Awake()
    {
        _fileNameTextReference.text = _fileName;

        if (_isMenuFolder) DataHandler._allPlayersFolder.Add(this);
    }

    private void Start()
    {
        OnDisplayChilds();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public void AddPlayerFile(PlayersFile file)
    {
        _controllers.Add(file);
    }

    public void GetPlayerFiles(ref List<PlayersFile> files)
    {
        _controllers = new();
        _controllers = files;
        //utilise _controllers.gameObject au lieu de _childs
    }

    public void OnDisplayChilds()
    {
        for(int i = 0; i < _controllers.Count; i++)
        {
            Vector3 pos = transform.position - Vector3.up * (i) * _heightDifference;
            pos += Vector3.right * _sidetDifference;
            
            _controllers[i].transform.position = pos;
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        DataHandler._currentFolderSelected = this;
        _onFolderSelected.myEvent?.Invoke();
    }

    public override void OnDrop()
    {
        base.OnDrop();
        if(DataHandler._currentFolderSelected == this)
        {
            DataHandler._lastFolderSelected = this;
            DataHandler._currentFolderSelected = null;
        }
    }

    public void DisableOrEnableControllers(bool _value)
    {
        foreach (var controller in _controllers)
        {
            controller.gameObject.SetActive(_value);
        }
    }

    public void OnFileMoved(PlayersFile p)
    {
        if (_controllers.Contains(p))
        {
            _controllers.Remove(p);

            OnDisplayChilds();
        }

    }
}
