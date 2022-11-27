using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Mantrap_Tarp : MonoBehaviour
{
    #region Trap variables
    [SerializeField] private int _damage;
    [SerializeField] private string _animName;
    private bool _isActiveTrap;
    #endregion

    #region Access to scripts or Component
    private Health _health;
    private Animator _anim;
    #endregion

    private void Start()
    {
        _health = FindObjectOfType<Health>();
        _anim = GetComponent<Animator>();
        _isActiveTrap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isActiveTrap == true)
        {
            if (collision.gameObject.CompareTag("CheckTrap"))
            {
                _anim.SetTrigger(_animName);
            }
        }
    }

    public void Attack()
    {       
        _health.TakeHit(_damage);
        _isActiveTrap = false;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
