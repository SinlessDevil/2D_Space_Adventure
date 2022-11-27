using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region Public Variabls
    public GameObject item;
    private Transform player;
    public int dropX;
    public int dropY;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void randomDrop()
    {
        dropY = Random.Range(1, 3);
        dropX = Random.Range(2, 6);
    }

    public void SpawnDroppedItem()
    {
        randomDrop();
        Vector2 playerPos = new Vector2(player.position.x + dropX, player.position.y - dropY);
        Instantiate(item, playerPos, Quaternion.identity);
    }

}
