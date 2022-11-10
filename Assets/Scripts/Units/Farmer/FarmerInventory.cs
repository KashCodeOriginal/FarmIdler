using UnityEngine;
using UnityEngine.Events;

public class FarmerInventory : MonoBehaviour
{
    public event UnityAction<int> IsCarrotAmountChanged; 

    [SerializeField] private int _carrotAmount;

    public void AddCarrot(int amount)
    {
        _carrotAmount += amount;
        
        IsCarrotAmountChanged?.Invoke(_carrotAmount);
    }
}
