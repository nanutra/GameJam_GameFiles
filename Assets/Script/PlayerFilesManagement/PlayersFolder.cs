using System.Collections.Generic;
using TMPro;
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

    private List<PlayersFile> _controllers = new();

    private void Awake()
    {
        _fileNameTextReference.text = _fileName;
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
    }

}
