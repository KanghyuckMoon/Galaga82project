using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePly : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float inputh;
    private PoolManager poolManager;
    [SerializeField]
    private GameObject bullet;


    private bool lefton;
    private bool upon;
    private bool righton;

    private void Awake()
    {
        poolManager = FindObjectOfType<PoolManager>(true);
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        UpMove();
        LeftMove();
        RightMove();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Upon();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            Upoff();
        }
            LimitStage();
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Lefton();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Righton();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Leftoff();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Rightoff();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upon = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upon = false;
        }
    }
    private void LeftMove()
    {
        if (!lefton) return;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - (-1 * 150 * Time.deltaTime));
    }
    private void RightMove()
    {
        if (!righton) return;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - (1 * 150 * Time.deltaTime));
    }
    private void UpMove()
    {
        if (!upon) return;
        rigid.AddForce(transform.right * (200 * Time.deltaTime));
    }

    public void Fire()
    {
        GameObject bull;
        if(poolManager.transform.childCount > 0)
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

    private void LimitStage()
    {
        if (transform.position.x > 45) transform.position = new Vector2(-44,transform.position.y);
        if (transform.position.x < -45) transform.position = new Vector2(44, transform.position.y);
        if (transform.position.y > 45) transform.position = new Vector2(transform.position.x, -44);
        if (transform.position.y < -45) transform.position = new Vector2(transform.position.x, 44);
    }
    public void Upon()
    {
        upon = true;
    }
    public void Upoff()
    {
        upon = false;
    }
    public void Lefton()
    {
        lefton = true;
    }
    public void Leftoff()
    {
        lefton = false;
    }
    public void Righton()
    {
        righton = true;
    }
    public void Rightoff()
    {
        righton = false;
    }
}
