using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayersFile : ClickableObject, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI _fileNameTextReference = null;

    [SerializeField]
    private Image _fileImageReference = null;

    [SerializeField]
    protected string _fileName;

    [SerializeField]
    protected string _fileNameSuffix;

    [SerializeField]
    private Transform _rightTextTransform;

    private Transform _baseTextTransform;

    [SerializeField]
    private bool _isRightOnStart = false;

    public List<CustomEvent> _controllersEvents;
    public List<ButtonFileEvent> _buttonsFiles;
    public CustomEvent _destroyEvent;
    public CustomEvent _renameEvent;
    public CustomEvent _duplicate;
    public CustomEvent _reset;
    public VerticalLayoutGroup _group;
    public ButtonFileEvent _prefabButton;

    public delegate void OnFileMoved(PlayersFile f);
    public static OnFileMoved onFileMove;

    private void Awake()
    {
        _fileNameTextReference.text = _fileName + "." + _fileNameSuffix;
        _baseTextTransform = _fileNameTextReference.transform;
        DataHandler._allCurrentFilesInOuindo.Add(this);
        SetTextPosition(_isRightOnStart);

    }

    private void Update()
    {
        /*        Debug.Log(DataHandler._clickedObject);
                Debug.Log(DataHandler._targetFromClickedObject);*/
        if (Input.GetMouseButtonDown(1))
        {
            if (DataHandler._rightOverObject == this)
            {
                Debug.Log(this,this);
                DataHandler._rightClickedObject = this;
            }

           
        }
        if (Input.GetMouseButtonUp(0))
        {
            /*
            if (DataHandler._targetFromClickedObject is not PlayersFolder || DataHandler._clickedObject != this) return;
            PlayersFolder _folder = DataHandler._targetFromClickedObject as PlayersFolder;
            var _tempFolder = _folder.ParentFiles;
            if (_tempFolder == null) return;
            onFileMove.Invoke(this);
            _tempFolder.AddPlayerFile(this);
            transform.SetParent(_folder.ParentFiles.transform);
            _tempFolder.OnDisplayChilds();
            SetTextPosition(true);

            DataHandler._targetFromClickedObject = null;
            DataHandler._clickedObject = null;/**/
        }

    }

    public override void OnDrop()
    {
        /*
        Debug.Log(this);

        base.OnDrop();
        Debug.Log(this);
        Debug.Log(DataHandler._targetFromClickedObject);

        if (DataHandler._targetFromClickedObject is not PlayersFolder) return;

        PlayersFolder _folder = DataHandler._targetFromClickedObject as PlayersFolder;
        var _tempFolder = _folder.ParentFiles;
        if (_tempFolder == null) return;
        Debug.Log("byufdobgvyfou");
        onFileMove.Invoke(this);
        _tempFolder.AddPlayerFile(this);

        /*       int i = _folder.ParentFiles.childCount;
               Vector3 pos = _folder.ParentFiles.transform.position - Vector3.up * (i) * 70;
               transform.position = pos;/**/
        /*
        transform.SetParent(_folder.ParentFiles.transform);
        _tempFolder.OnDisplayChilds();
        SetTextPosition(true);

        DataHandler._targetFromClickedObject = null;
        DataHandler._clickedObject = null;
        /**/
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    public void SetTextPosition(bool _rightSide)
    {
        if (_rightSide)
        {
            _fileNameTextReference.transform.position = _fileImageReference.transform.position + Vector3.right * 135;
            _fileNameTextReference.alignment = TextAlignmentOptions.Left;
        }
        else
        {
            _fileNameTextReference.transform.position = _baseTextTransform.position;
        }
    }

}
