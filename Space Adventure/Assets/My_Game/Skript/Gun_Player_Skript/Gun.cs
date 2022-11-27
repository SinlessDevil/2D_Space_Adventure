using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Private variabls
    [SerializeField] private float offset;
    private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;
    private float rotZ;
    [SerializeField] private int currentAmmo;
    private AmmoMeneger ammoMeneger;
    private Animator canAnim;
    #endregion

    #region Public variabls
    public GameObject bullet;
    public Transform shotPoint;
    public Joystick joystick;

    public ControlType controlType;
    public enum ControlType { Pistol_or_Machinegun, shootgun}
    public Transform[] shootGunPoint;
    #endregion

    private void Start()
    {
        canAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        ammoMeneger = FindObjectOfType<AmmoMeneger>();
    }

    private void Update()
    {
        JoystickMove();
        JoystickShoot();
    }

    private void JoystickMove()
    {
        if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    private void JoystickShoot()
    {
        if (timeBtwShots <= 0)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (ammoMeneger.Ammo > 0)
                {
                    InstBullet();
                    ammoMeneger.Ammo -= currentAmmo;
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void InstBullet()
    {

        if (controlType == ControlType.Pistol_or_Machinegun)
        {
            canAnim.SetTrigger("isShake");
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else if (controlType == ControlType.shootgun)
        {
            for (int i = 0; i < shootGunPoint.Length; i++)
            {
                canAnim.SetTrigger("isShake");
                Instantiate(bullet, shootGunPoint[i].position, shootGunPoint[i].rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
    }
}
