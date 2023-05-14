using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectSpawnFile : PlayersFile
{
   

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
    }

    public void HandlerUnregisterEvent()
    {
        _destroyEvent.myEvent -= OnDestroyFile;
        _renameEvent.myEvent -= OnRenameFile;
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
            Debug.Log("D�truire le wall genre");
            onFileMove?.Invoke(this);
            Destroy(gameObject);
        }
    }

    //Player va penser que �a le cr�e
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
}
