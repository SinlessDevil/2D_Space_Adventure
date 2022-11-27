using UnityEngine;

public class Trap : MonoBehaviour
{
    #region Trap variables
    [SerializeField] private int _damage;
    private bool _isNearPlayer = false;
    #endregion

    #region Access to scripts or Component
    private Health _health;
    #endregion

    private void Start()
    {
        _health = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isNearPlayer = true;
        if (_isNearPlayer == true)
        {
            if (collision.gameObject.CompareTag("CheckTrap"))
            {
                _health.TakeHit(_damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isNearPlayer = false;
    }
}
