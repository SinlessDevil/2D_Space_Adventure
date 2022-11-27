using UnityEngine;

public class Player_Movemant : MonoBehaviour
{
    #region Public Joystick
    public ControlType controlType;
    public enum ControlType {PC, Android}
    public Joystick joystick;
    #endregion

    #region Movement
    private Rigidbody2D rb;
    public Animator anim;

    public float moveSpeed;
    public float x, y;

    private bool _iswalking;
    private Vector3 _moveDir;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(controlType == ControlType.PC)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }
        else if(controlType == ControlType.Android)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }

        if (x != 0 || y != 0)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
            if (!_iswalking)
            {
                _iswalking = true;
                anim.SetBool("isMoving", _iswalking);
            }
        }
        else
        {
            if (_iswalking)
            {
                _iswalking = false;
                anim.SetBool("isMoving", _iswalking);
                StopMoving();
            }
        }

        _moveDir = new Vector3(x, y).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = _moveDir * moveSpeed * Time.deltaTime;
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
}
