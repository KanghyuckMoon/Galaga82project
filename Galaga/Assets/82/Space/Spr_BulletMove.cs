using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spr_BulletMove : MonoBehaviour
{
    public float Speed;
    public float angle;
    protected PoolManager poolManager;

    private void Awake()
    {
        poolManager = FindObjectOfType<PoolManager>(true);
    }

    private void OnEnable()
    {
        Invoke("onfalse", 2f);
        GetComponent<Rigidbody2D>().AddForce(transform.right * Speed, ForceMode2D.Impulse);
    }

    private void onfalse()
    {
        transform.SetParent(poolManager.transform);
        gameObject.SetActive(false);

    }


}
