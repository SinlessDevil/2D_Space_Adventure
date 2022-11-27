using UnityEngine;

public class Boss_Trap : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetTrigger("Destroy");
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
