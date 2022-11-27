using UnityEngine;

public class TrapArrow : MonoBehaviour
{
    public Transform pointAttak;
    public GameObject arrowObj;
    [SerializeField] private int _amountArrows = 40;
    private float _timeReload;
    [SerializeField] private float _startTimeReload;

    [SerializeField] private bool _isPlayerNear;

    private void SpawnArrow()
    {
        if (_amountArrows > 0)
        {
            Instantiate(arrowObj, pointAttak.position, Quaternion.identity);
            _amountArrows--;
            _timeReload = _startTimeReload;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _isPlayerNear = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
         _isPlayerNear = true;
    }

    private void Update()
    {
        if (_isPlayerNear == true)
        {
            if (_timeReload <= 0)
            {
                SpawnArrow();
            }
            else
            {
                _timeReload -= Time.deltaTime;
            }
        }
    }

}

