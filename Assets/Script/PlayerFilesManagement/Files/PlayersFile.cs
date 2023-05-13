using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayersFile : ClickableObject
{
    [SerializeField]
    private TextMeshProUGUI _fileNameTextReference = null;

    [SerializeField]
    private Image _fileImageReference = null;

    [SerializeField]
    private string _fileName;

    [SerializeField]
    protected string _fileNameSuffix;

    [SerializeField]
    private Transform _rightTextTransform;

    private Transform _baseTextTransform;

    [SerializeField]
    private bool _isRightOnStart = false;

    public delegate void OnFileMoved(PlayersFile f);
    public static OnFileMoved onFileMove;

    private void Awake()
    {
        _fileNameTextReference.text = _fileName + "." + _fileNameSuffix;
        _baseTextTransform = _fileNameTextReference.transform;
        DataHandler._allCurrentFilesInOuindo.Add(this);
        SetTextPosition(_isRightOnStart);

    }

    public override void OnDrop()
    {
        base.OnDrop();
        if (DataHandler._targetFromClickedObject is not PlayersFolder) return;
        onFileMove.Invoke(this);
        PlayersFolder _folder = DataHandler._targetFromClickedObject as PlayersFolder;
        var _tempFolder = _folder.ParentFiles.GetComponent<PlayersFolder>();
        _tempFolder.AddPlayerFile(this);

        /*       int i = _folder.ParentFiles.childCount;
               Vector3 pos = _folder.ParentFiles.transform.position - Vector3.up * (i) * 70;
               transform.position = pos;*/
        transform.SetParent(_folder.ParentFiles);
        _tempFolder.OnDisplayChilds();
        SetTextPosition(true);

        DataHandler._targetFromClickedObject = null;
        DataHandler._clickedObject = null;

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
