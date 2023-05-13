using UnityEngine;
using UnityEngine.EventSystems;

public class PlayersFolder : ClickableObject
{
    [SerializeField]
    private Transform _parentFiles;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void OnDrop(PointerEventData eventData)
    {
        //si l'objet auquel la personne a cliqué est un fichier, on le bouge dans le dossier
        if(DataHandler._clickedObject is File) DataHandler._clickedObject.transform.SetParent(transform);
        base.OnDrop(eventData);
    }
}
