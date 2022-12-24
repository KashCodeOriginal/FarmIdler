using UnityEngine.Events;

namespace Units.Bed.Model
{
    public interface IInteractable
    {
        public event UnityAction<Bed> IsBedInteracted;
        public void Interact();
    }
}
