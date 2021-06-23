using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemypool;
    private int random;
    private GameObject enemy;

    private void Update()
    {
        PoolEnemy();
    }

    private void PoolEnemy()
    {
        if (enemypool.transform.childCount > 0)
        {
            random = Random.Range(0, 2);
            enemy = enemypool.transform.GetChild(0).gameObject;
            if(random == 0)
            {
                enemy.transform.position = new Vector2(Random.Range(-8.7f, -3.1f), 7);
            }
            else
            {
                enemy.transform.position = new Vector2(Random.Range(8.7f, 3.1f), 7);
            }
            enemy.SetActive(true);
            enemy.GetComponent<Collider2D>().enabled = true;
            enemy.transform.SetParent(null);
        }
    }
}
