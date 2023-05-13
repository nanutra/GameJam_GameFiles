using System;
using UnityEngine;

public class GameFileFolder : PlayersFolder
{
    public CustomEvent OnGameFileOpenEvent;

    public override void OnEnable()
    {
        base.OnEnable();
        OnGameFileOpenEvent.myEvent += OnGameFileFolderOpen;
    }



    public override void OnDisable()
    {
        base.OnDisable();
        OnGameFileOpenEvent.myEvent -= OnGameFileFolderOpen;
    }

    public override void ClickCount()
    {
        OnGameFileFolderOpen();
    }
    private void OnGameFileFolderOpen()
    {
        //
        Debug.Log("CallDelegateGameFileFoldre");
        OnGameFileOpenEvent.myEvent?.Invoke();
    }
}
