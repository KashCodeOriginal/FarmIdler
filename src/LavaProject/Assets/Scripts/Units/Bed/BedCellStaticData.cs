using UnityEngine;

[CreateAssetMenu(menuName = "Cells/BedCell", fileName = "BedCellStaticData", order = 0)]
public class BedCellStaticData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _experience;
    [SerializeField] private int _timeBetweenGrowingStages;
    [SerializeField] private bool _isExperienceGivable;
    [SerializeField] private bool _isCollectable;


    public string Name => _name;

    public Sprite Icon => _icon;

    public GameObject Prefab => _prefab;

    public int Experience => _experience;

    public int TimeBetweenGrowingStages => _timeBetweenGrowingStages;

    public bool IsExperienceGivable => _isExperienceGivable;

    public bool IsCollectable => _isCollectable;
}

