using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletprefeb;
    GameObject bullet = null;
    Vector2 min;
    Vector2 max;
    [SerializeField]
    GameObject poolManager;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject layser;
    [SerializeField]
    private Image laysercoolimage;

    WaitForSeconds delay;
    WaitForEndOfFrame endframe;
    private float bulletTimer = 0.1f;
    private int laysercooltime = 100;

    private bool lefton;
    private bool righton;
    private bool attackon;
    private bool layseron;
    private bool laysercharge;

    private void Awake()
    {
        delay = new WaitForSeconds(0.1f);
        endframe = new WaitForEndOfFrame();
        min = new Vector2(-0.25f, 0);
        max = new Vector2(0.25f, 0);
    }
    void Update()
    {
        if(laysercooltime < 100)
        {
            laysercooltime += 1;
        }
        else
        {
            laysercharge = false;
        }
        laysercoolimage.fillAmount = (float)laysercooltime / 100;
        bulletTimer -= Time.deltaTime;
        LeftMove();
        RightMove();
        if(Input.GetKeyDown(KeyCode.LeftArrow))
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attackon();
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Attackoff();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Layseron();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Layseroff();
        }
        Fire();
        layser.SetActive(false);
        Layser();
        if (transform.position.x > 0.25f) transform.position = max;
        else if (transform.position.x < -0.25f) transform.position = min;
    }

    private void LeftMove()
    {
        if (!lefton) return;
        transform.position = new Vector2(transform.position.x + -1 * speed * Time.deltaTime, 0);
    }
    private void RightMove()
    {
        if (!righton) return;
        transform.position = new Vector2(transform.position.x + 1 * speed * Time.deltaTime, 0);
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
    public void Attackon()
    {
        attackon = true;
    }
    public void Attackoff()
    {
        attackon = false;
    }

    public void Fire()
    {
        if (!attackon) return;
        if (bulletTimer > 0)
            {
                return;
            }
            InstantiateOrSpawn();
            bullet = null;
            bulletTimer = 0.1f;
    }
    public void Layseron()
    {
        layseron = true;
    }
    public void Layseroff()
    {
        layseron = false;
    }
    public void Layser()
    {
        if (!layseron) return;
        if (laysercharge) return;
        if (laysercooltime < 10)
        {
            laysercharge = true;
            return;
        }
        layser.SetActive(true);
        layser.transform.position = new Vector2(transform.position.x,0);
        if (laysercooltime > 0) laysercooltime -= 5;
    }
    private void InstantiateOrSpawn()
    {
        if (poolManager.transform.childCount > 0)
        {
            bullet = poolManager.transform.GetChild(0).gameObject;
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.transform.SetParent(null);
        }
    }
}
