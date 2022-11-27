using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int collisiondamage = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == collisionTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(collisiondamage);
        }
    }
}
