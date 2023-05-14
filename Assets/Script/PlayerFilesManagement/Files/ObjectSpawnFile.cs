using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectSpawnFile : PlayersFile
{
    [SerializeField] private List<GameObject> _gameObject;   
    [SerializeField] private List<Vector3> _startPos = new();   
    
    public override void OnEnable()
    {
        base.OnEnable();
        HandlerRegisterToEvents();
    }

    public void OnDestroy()
    {
        HandlerUnregisterEvent();
    }

    private void Start()
    {
        if (_gameObject.Count <= 0) return;
        for(int i = 0; i < _gameObject.Count; i++)
        {
            _startPos.Add(_gameObject[i].transform.position);
        }
        for(int i = 0; i < _controllersEvents.Count; i++)
        {
            var buttonEvent = Instantiate(_prefabButton, _group.transform);
            buttonEvent._event = _controllersEvents[i];
            string[] subs = buttonEvent._event.name.Split("_");

            buttonEvent._textMPRO.text = subs[1] + " " + _fileName;
            _buttonsFiles.Add(buttonEvent);
        }
        _group.gameObject.SetActive(false);
    }

    public void HandlerRegisterToEvents()
    {
        _destroyEvent.myEvent += OnDestroyFile;
        _renameEvent.myEvent += OnRenameFile;
        _duplicate.myEvent += OnDuplicate;
        _reset.myEvent += OnReset;
  //          public CustomEvent _duplicate;
//    public CustomEvent _reset;
}

    public void HandlerUnregisterEvent()
    {
        _destroyEvent.myEvent -= OnDestroyFile;
        _renameEvent.myEvent -= OnRenameFile;
        _duplicate.myEvent -= OnDuplicate;
        _reset.myEvent -= OnReset;
    }

    private void OnDuplicate()
    {
        var _temp = _gameObject;
        for (int i = 0; i < _temp.Count; i++)
        {
            GameObject g = Instantiate(_temp[i], _startPos[i], Quaternion.identity);
            _gameObject.Add(g);
            _startPos.Add(g.transform.position);
        }
    }

    private void OnReset()
    {
        for (int i =0; i < _gameObject.Count; i++)
        {
            _gameObject[i].SetActive(true);
            _gameObject[i].transform.position = _startPos[i];
        }
    }

    private void OnRenameFile()
    {
        if(DataHandler._rightClickedObject == this)
        {
            //rename le file genre   
            Debug.Log("rename me " + this, this);
        }

    }

    private void OnDestroyFile()
    {
        if (DataHandler._rightClickedObject == this)
        {

            foreach(var v in _gameObject)
            {
                v.SetActive(false);
            }
/*            Debug.Log("Détruire le wall genre");
            onFileMove?.Invoke(this);
            Destroy(gameObject);*/
        }
    }

    //Player va penser que ça le crée
    public void TeleportObjectInLevel()
    {
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            _group.gameObject.SetActive(true);
        }
        base.OnPointerClick(eventData);
    }
    public void OnButtonClicked()
    {

    }
}
