using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCam : MonoBehaviour
{
    private float shkaeTime = 0;
    private float shkaeAmount = 0;
    [SerializeField]
    Vector3 starttransform;
    // Start is called before the first frame update

    private void Start()
    {
        starttransform = transform.position;
    }
    void LateUpdate()
    {
        if (shkaeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shkaeAmount + new Vector3(transform.position.x, transform.position.y, transform.position.z);
            shkaeTime -= Time.deltaTime;

        }
        else
        {
            shkaeTime = 0;
            transform.position = starttransform;
        }
    }

    public void jindong()
    {
        shkaeTime = 0.05f;
        shkaeAmount = 0.01f;
    }
}
