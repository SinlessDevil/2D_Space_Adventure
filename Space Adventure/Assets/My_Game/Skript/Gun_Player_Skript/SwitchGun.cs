using UnityEngine;

public class SwitchGun : MonoBehaviour
{
    #region Pistol
    [Header("PISTOL")]
    [SerializeField] private GameObject[] _pistol;
    [SerializeField] private bool _activePistol;
    #endregion
    #region Shootgun
    [Header("SHOOTGUN")]
    [SerializeField] private GameObject[] _shootgun;
    [SerializeField] private bool _activeShootgun;
    #endregion
    #region Machinegun
    [Header("MACHINEGUN")]
    [SerializeField] private GameObject[] _machinegun;
    [SerializeField] private bool _activeMachinegun;
    #endregion
    private void Start()
    {
        _activePistol = false;
        _activeShootgun = false;
        _activeMachinegun = false;
    }
    public void ResetGun()
    {
        _activePistol = false;
        _activeMachinegun = false;
        _activeShootgun = false;
        for (int i = 0; i < _pistol.Length; i++)
        {
            _pistol[i].SetActive(false);
            _shootgun[i].SetActive(false);
            _machinegun[i].SetActive(false);
        }
    }

    #region Button Click Change
    public void ButtonClickÑhangePistol()
    {
        if(_activePistol == false)
        {
            ResetGun();
            _activePistol = true;
            ActivePistol();
        }
        else if(_activePistol == true)
        {
            _activePistol = false;
            NotActivePistol();
        }
    }
    public void ButtonClickChangeShootgun()
    {
        if (_activeShootgun == false)
        {
            ResetGun();
            _activeShootgun = true;
            ActiveShootgun();
        }
        else if (_activeShootgun == true)
        {
            _activeShootgun = false;
            NoActiveShootgun();
        }
    }
    public void ButtonClickÑhangeMachinegun()
    {
        if (_activeMachinegun == false )
        {
            ResetGun();
            _activeMachinegun = true;
            ActiveMachinegun();
        }
        else if (_activeMachinegun == true)
        {
            _activeMachinegun = false;
            NoActiveMachinegun();
        }
    }
    #endregion

    #region Active Gun
    private void ActivePistol()
    {
        for (int i = 0; i < _pistol.Length; i++)
        {
            _pistol[i].SetActive(true);
        }
    }
    private void NotActivePistol()
    {
        for (int i = 0; i < _pistol.Length; i++)
        {
            _pistol[i].SetActive(false);
        }
    }

    private void ActiveShootgun()
    {
        for (int i = 0; i < _shootgun.Length; i++)
        {
            _shootgun[i].SetActive(true);
        }
    }
    private void NoActiveShootgun()
    {
        for (int i = 0; i < _shootgun.Length; i++)
        {
            _shootgun[i].SetActive(false);
        }
    }

    private void ActiveMachinegun()
    {
        for (int i = 0; i < _machinegun.Length; i++)
        {
            _machinegun[i].SetActive(true);
        }
    }
    private void NoActiveMachinegun()
    {
        for (int i = 0; i < _machinegun.Length; i++)
        {
            _machinegun[i].SetActive(false);
        }
    }
    #endregion
}
