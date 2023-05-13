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

    private void Awake()
    {
        _fileNameTextReference.text = _fileName + "." + _fileNameSuffix;
        _baseTextTransform = _fileNameTextReference.transform;
        DataHandler._allCurrentFilesInOuindo.Add(this);
    }

    public override void OnDrop()
    {
        base.OnDrop();
        if (DataHandler._targetFromClickedObject is not PlayersFolder) return;
        PlayersFolder _folder = DataHandler._targetFromClickedObject as PlayersFolder;
        _folder.AddPlayerFile(this);
        //transform.SetParent(_folder.ParentFiles);
    }

    public void SetTextPosition(bool _rightSide)
    {
        if (_rightSide)
        {
            _fileNameTextReference.transform.position = _fileImageReference.transform.position + Vector3.right * 50;
            _fileNameTextReference.alignment = TextAlignmentOptions.Left;
        }
        else
        {
            _fileNameTextReference.transform.position = _baseTextTransform.position;
        }
    }

}
