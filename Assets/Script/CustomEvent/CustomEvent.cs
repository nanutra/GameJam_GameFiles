using UnityEngine;

[CreateAssetMenu(fileName = "Custom Event", menuName = "new Custom Event")]
public class CustomEvent : ScriptableObject
{
    public delegate void test();
    public test myEvent;

    public void Raise()
    {
        myEvent?.Invoke();
    }
}