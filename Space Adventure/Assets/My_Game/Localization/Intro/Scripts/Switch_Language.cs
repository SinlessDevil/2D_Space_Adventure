using UnityEngine;

public class Switch_Language : MonoBehaviour
{
    private Animator _anim;
    private bool _isActive = false;
    [SerializeField] private string _nameAnim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void SwitchAnimaton()
    {
        if (!_isActive)
        {
            _anim.SetBool(_nameAnim, true);
            _isActive = true;
        }
        else
        {
            _anim.SetBool(_nameAnim, false);
            _isActive = false;
        }
    }
}
