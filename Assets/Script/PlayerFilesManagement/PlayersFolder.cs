using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayersFolder : ClickableObject
{
    [SerializeField]
    private PlayersFolder _parentFiles;

    public PlayersFolder ParentFiles => _parentFiles;

    [SerializeField]
    private TextMeshProUGUI _fileNameTextReference = null;

    [SerializeField]
    private string _fileName;

    [SerializeField]
    private List<PlayersFile> _controllers = new();
    [SerializeField]
    protected List<GameObject> _gos = new();
    [SerializeField]
    private float _heightDifference = 70;
    private float _sidetDifference = 0;

    [SerializeField]
    private CustomEvent _onFolderSelected;

    [SerializeField]
    private TextMeshProUGUI _targetText;

    bool canTask = false;

    public override void OnEnable()
    {
        base.OnEnable();
        PlayersFile.onFileMove += OnFileMoved;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PlayersFile.onFileMove -= OnFileMoved;
        canTask = false;
    }

    private void Awake()
    {
        canTask = true;
        _fileNameTextReference.text = _fileName;
    }

    private void Start()
    {
        OnDisplayChilds();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public async void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(DataHandler._rightClickedObject == null)
            {
                ObjectSpawnFile.display?.Invoke();
            }
            else
            {
                await Task.Delay(100);
                if (!canTask) return;
                DataHandler._rightClickedObject = null;
                ObjectSpawnFile.display?.Invoke();

            }

        }
        else
        {
            if(Input.GetMouseButtonDown(1))
            {
                if (DataHandler._rightClickedObject == null)
                {
                    ObjectSpawnFile.display?.Invoke();
                }
            }
        }
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
        //base.OnPointerClick(eventData);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            DataHandler._clickedObject = this;
        }
        _clickCount++;
        if (_clickCount < 2) return;

        ClickCount();
        DataHandler._currentFolderSelected = this;
        _clickCount = 0;
        foreach (var v in DataHandler._allWindowFolder)
        {
            if (v != _parentFiles) v.gameObject.SetActive(false);
            else v.gameObject.SetActive(true);
        }
        DataHandler.FileWindow.SetActive(true);
        //_onFolderSelected.myEvent?.Invoke();
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

    public void OnFileMoved(PlayersFile p)
    {
        if (_controllers.Contains(p))
        {
            _controllers.Remove(p);

            OnDisplayChilds();
        }

    }
    
    public override void ClickCount()
    {
        if(_targetText != null) _targetText.text = _fileName;
    }
}
