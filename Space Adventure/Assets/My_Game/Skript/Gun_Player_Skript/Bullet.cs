using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Private variabls
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private int damage;
    [SerializeField] private float _lifetime;
    #endregion

    #region Public variabls
    public LayerMask whatIsSolid;
    public string[] enemyName;

    public GameObject effect_bullet;
    public Transform center_object;
    #endregion

    private void Start()
    {
        Invoke("DestroyBullet", _lifetime);
    }

    private void Update()
    {
        CheckSolid();
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void CheckSolid()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            for (int i = 0; i < enemyName.Length; i++)
            {
                if (hitInfo.collider.CompareTag(enemyName[i]))
                {
                    GameManager.InstanceObject(center_object, effect_bullet);
                    hitInfo.collider.GetComponent<Enemy_Health>().TakeDamage(damage);
                }
            }
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
