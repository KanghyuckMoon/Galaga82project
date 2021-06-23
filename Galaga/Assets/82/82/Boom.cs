using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField]
    private GameObject boomManager;

    private void Awake()
    {
        boomManager = FindObjectOfType<BoomManage>().gameObject;
    }
    public void Disible()
    {
        transform.SetParent(boomManager.transform);
        gameObject.SetActive(false);
    }
}
