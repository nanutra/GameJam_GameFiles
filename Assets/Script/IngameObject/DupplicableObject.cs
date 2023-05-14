using UnityEngine;

public class DupplicableObject : MonoBehaviour
{
    public CustomEvent _event;
    public float _offsetY;

    private void OnEnable()
    {
        _event.myEvent += OnObjectDupplicated;
    }

    private void OnDisable()
    {
        _event.myEvent -= OnObjectDupplicated;
    }

    private void OnObjectDupplicated()
    {
        Instantiate(this.gameObject, this.transform.position + Vector3.up * _offsetY, Quaternion.identity);
    }
}
