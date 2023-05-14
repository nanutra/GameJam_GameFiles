using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFileEvent : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI _textMPRO;
    public CustomEvent _event;

    public void OnPointerClick(PointerEventData eventData)
    {
        //if left click raise
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            _event.myEvent?.Invoke();
            //DataHandler._rightClickedObject.
        }
    }
}
