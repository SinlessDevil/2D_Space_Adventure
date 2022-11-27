using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    #region Private variabls
    [SerializeField] private float _speedArrow;
    [SerializeField] private float _distanceArrow;
    [SerializeField] private int _damageArrow;
    [SerializeField] private float _lifetimeArrow;
    #endregion

    #region Public variabls
    public LayerMask whatIsSolid;

    public GameObject effect_arrow;
    public Transform center_object;
    #endregion

    private void Start()
    {
        Invoke("DestroyBullet", _lifetimeArrow);
    }

    private void Update()
    {
        CheckSolid();
        transform.Translate(Vector2.up * _speedArrow * Time.deltaTime);
    }

    private void CheckSolid()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distanceArrow, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                GameManager.InstanceObject(center_object, effect_arrow);
                hitInfo.collider.GetComponent<Health>().TakeHit(_damageArrow);
            }
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
