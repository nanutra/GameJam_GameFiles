using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler 
{
    public static bool IsGamePause = false;

    public static bool IsFolderWindowOpen = false;

    public static ClickableObject _clickedObject = null;

    public static ClickableObject _targetFromClickedObject = null;

    public static List<PlayersFile> _allCurrentFilesInOuindo = new List<PlayersFile>();

}


