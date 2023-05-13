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

    private List<PlayersFile> _controllers = new();

    [SerializeField]
    private List<GameObject> l_childs;

    [SerializeField]
    private float _heightDifference = 50;
    private float _sidetDifference = 35;

    private void Awake()
    {
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

    public void OnChangeChildren(GameObject go)
    {
        l_childs.Add(go) ;
    }

    private void OnDisplayChilds()
    {
        for(int i = 0; i < l_childs.Count; i++)
        {

            Vector3 pos = transform.position - Vector3.up * (i + 1) * _heightDifference;
            pos += Vector3.right * _sidetDifference;
            l_childs[i].transform.position = pos;
        }
    }

}
