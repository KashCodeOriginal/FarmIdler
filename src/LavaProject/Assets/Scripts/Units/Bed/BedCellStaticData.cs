using UnityEngine;

[CreateAssetMenu(menuName = "Cells/BedCell", fileName = "BedCellStaticData", order = 0)]
public class BedCellStaticData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _experience;
    [SerializeField] private int _timeBetweenGrowingStages;
}