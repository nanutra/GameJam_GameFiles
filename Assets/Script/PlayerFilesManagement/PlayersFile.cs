using UnityEngine.EventSystems;
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

}
