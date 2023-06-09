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

        base.ClickCount();
        foreach (var v in _gos)
        {
            v.gameObject.SetActive(true);
        }
        OnGameFileFolderOpen();
    }
    private void OnGameFileFolderOpen()
    {

        //
        if (DataHandler.IsFolderWindowOpen) return;
        DataHandler.IsFolderWindowOpen = true;
        OnGameFileOpenEvent.myEvent?.Invoke();
    }
}
