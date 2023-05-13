using UnityEngine;
using TMPro;

public class PlayersFile : ClickableObject
{
    [SerializeField]
    private TextMeshProUGUI _fileNameTextReference = null;

    [SerializeField]
    private string _fileName;

    [SerializeField]
    protected string _fileNameSuffix;

    private void Awake()
    {
        _fileNameTextReference.text = _fileName + "." + _fileNameSuffix;
    }

    public override void OnDrop()
    {
        base.OnDrop();
        if (DataHandler._targetFromClickedObject is not PlayersFolder) return;
        PlayersFolder _folder = DataHandler._targetFromClickedObject as PlayersFolder;
        _folder.AddPlayerFile(this);
        transform.SetParent(_folder.ParentFiles);
    }

}
