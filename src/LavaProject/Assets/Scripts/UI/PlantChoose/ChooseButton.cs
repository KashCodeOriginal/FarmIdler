using UnityEngine;
using UnityEngine.UI;

public class ChooseButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    public Button Button => _button;
    public BedCellStaticData BedCellStaticData { get; private set; }

    public void SetUp(BedCellStaticData bedCellStaticData)
    {
        BedCellStaticData = bedCellStaticData;

        _icon.sprite = bedCellStaticData.Icon;
    }
}
