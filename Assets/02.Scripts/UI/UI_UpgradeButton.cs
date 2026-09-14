using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeButton : MonoBehaviour
{
    private Button[] _buttons;

    private void Start()
    {
        _buttons = GetComponentsInChildren<Button>();
    }

    private void Update()
    {
    }
}