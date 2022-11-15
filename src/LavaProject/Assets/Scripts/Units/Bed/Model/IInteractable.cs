using UnityEngine.Events;

public interface IInteractable
{
    public event UnityAction<Bed> IsBedInteracted;
    public void Interact();
}
