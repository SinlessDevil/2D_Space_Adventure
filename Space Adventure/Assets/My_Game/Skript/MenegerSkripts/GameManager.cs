using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void InstanceObject(Transform point, GameObject objectPoint)
    {
        Instantiate(objectPoint, point.transform.position, Quaternion.identity);
    }
}
