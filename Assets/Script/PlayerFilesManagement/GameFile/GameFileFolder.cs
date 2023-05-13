using System;

public class GameFileFolder : PlayersFolder
{
    public CustomEvent OnGameFileOpenEvent;

    public override void OnEnable()
    {
        base.OnEnable();
        OnGameFileOpenEvent.myEvent += OnGameFileFolderOpen;
    }

    private void OnGameFileFolderOpen()
    {
        //
        OnGameFileOpenEvent.myEvent?.Invoke();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        OnGameFileOpenEvent.myEvent -= OnGameFileFolderOpen;
    }
}
