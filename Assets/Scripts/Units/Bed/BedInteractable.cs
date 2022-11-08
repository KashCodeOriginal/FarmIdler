using UnityEngine;
using UnityEngine.Events;

public class BedInteractable : MonoBehaviour, IInteractable
{
    private Bed _bed;

    private void Start()
    {
        _bed = GetComponent<Bed>();
    }

    public event UnityAction<Bed> IsBedInteracted;

    public void Interact()
    {
        IsBedInteracted?.Invoke(_bed);
    }
}
