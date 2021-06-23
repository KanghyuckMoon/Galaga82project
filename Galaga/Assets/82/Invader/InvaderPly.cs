using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderPly : MonoBehaviour
{
    [SerializeField]
    private GameObject poolManager;
    [SerializeField]
    private GameObject bullet;
    Vector2 mouse;
    float angle;
    float bulletTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(Input.GetMouseButton(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
        if (bulletTimer > 0)
        {
            return;
        }
        Pool();
        bulletTimer = 0.1f;
    }
    public void Pool()
    {
        GameObject bull;
        if (poolManager.transform.childCount > 0)
        {
            bull = poolManager.transform.GetChild(0).gameObject;
            bull.transform.position = transform.position;
            bull.transform.rotation = transform.rotation;
            bull.transform.SetParent(null);
            bull.SetActive(true);
        }
        else
        {
            bull = Instantiate(bullet, transform.position, transform.rotation);
            bull.transform.SetParent(null);
            bull.SetActive(true);
        }
    }
}
