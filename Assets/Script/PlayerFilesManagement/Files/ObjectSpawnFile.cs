using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSpawnFile : PlayersFile
{
    [SerializeField] private List<GameObject> _gameObject;   
    [SerializeField] private List<GameObject> _saveGameObject;   
    [SerializeField] private List<Vector3> _startPos = new();

    public delegate void Display();
    public static Display display;

    public bool IsWindows = false;

    public override void OnEnable()
    {
        base.OnEnable();
        HandlerRegisterToEvents();
        display += ResetDisplay;
    }

    public void OnDestroy()
    {
        HandlerUnregisterEvent();
        display -= ResetDisplay;

    }

    private void Start()
    {
        if(_gameObject.Count > 0)
        for(int i = 0; i < _gameObject.Count;i++)
        {
            _saveGameObject.Add(Instantiate(_gameObject[i]));
            _startPos.Add(_gameObject[i].transform.position);
            _saveGameObject[i].SetActive(false);
        }

        for (int i = 0; i < _controllersEvents.Count; i++)
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
        if (DataHandler._rightClickedObject != this) return;

        var _temp = _saveGameObject.Count;
        if (_temp <= 0) return;
        for (int i = 0; i < _temp; i++)
        {
            if (_saveGameObject[i] != null )
            {
                GameObject g = Instantiate(_saveGameObject[i], _startPos[i], _saveGameObject[i].transform.rotation);
                g.SetActive(true); ;
                _gameObject.Add(g);
            }
        }
    }

    private void OnReset()
    {
        if (DataHandler._rightClickedObject != this) return;

        
        for (int i =0; i < _gameObject.Count; i++)
        {
            Destroy(_gameObject[i]);
        }
        _gameObject = new();
        
        for (int i = 0; i < _saveGameObject.Count; i++)
        {
            GameObject g = Instantiate(_saveGameObject[i], _startPos[i], _saveGameObject[i].transform.rotation);
            _gameObject.Add(g);
            g.SetActive(true);
        }
        /**/
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
            if(IsWindows)Application.Quit();
            foreach (var v in _gameObject)
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
            display?.Invoke();
            _group.gameObject.SetActive(true);
        }

        base.OnPointerClick(eventData);
    }

    public void ResetDisplay()
    {
        _group.gameObject.SetActive(false);

    }

    public void OnButtonClicked()
    {

    }
}
