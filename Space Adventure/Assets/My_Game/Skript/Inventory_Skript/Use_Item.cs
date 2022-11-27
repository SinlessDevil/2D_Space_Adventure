using UnityEngine;

public class Use_Item : MonoBehaviour
{
    private SwitchGun _switchgun;
    private Health _playerHealth;
    private readonly int _bonusehp = 10;

    private void Start()
    {
        _switchgun = FindObjectOfType<SwitchGun>();
        _playerHealth = FindObjectOfType<Health>();
    }

    public void ButtonClickSwitchPistol()
    {
        _switchgun.ButtonClick—hangePistol();
    }
    public void ButtonClickSwitchShootGun()
    {
        _switchgun.ButtonClickChangeShootgun();
    }
    public void ButtonClickSwitchMachineGun()
    {
        _switchgun.ButtonClick—hangeMachinegun();
    }
    public void ButtonClickPlayerHealth()
    {
        _playerHealth.SetHealth(_bonusehp);
        GameManager.InstanceObject(_playerHealth.centerGameObejct, _playerHealth.effectHealth);
        Destroy(this.gameObject);
    }
}
