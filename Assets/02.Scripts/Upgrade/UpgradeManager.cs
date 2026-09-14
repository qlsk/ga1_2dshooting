using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // 업그레이드 관리자: 업그레이드들에 대한 무결성 생성, 조회, 수정, 삭제 등과 관련된 게임 로직

    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    // 업그레이드 UI
    [SerializeField] private UI_Upgrade[] _uiUpgrades;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    // UI 갱신
    public void LevelUp(int index)
    {
        _upgrades[index].LevelUp();

        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }
}