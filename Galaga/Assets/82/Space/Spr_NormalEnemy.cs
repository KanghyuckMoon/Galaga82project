using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spr_NormalEnemy : MonoBehaviour
{
    protected SpacePly ply;
    protected Rigidbody2D rigid;
    [SerializeField]
    protected int hp;
    protected GameManagerSpace gameManager;
    [SerializeField]
    protected float speed = 15f;
    protected PoolManager poolManager;
    protected SpriteRenderer spriteRenderer;
    protected WaitForSeconds dely = new WaitForSeconds(0.1f);
    public bool isDamaged;
    private BoomManage boomManager;
    [SerializeField]
    private GameObject boomprefeb;

    private void Start()
    {
        boomManager = FindObjectOfType<BoomManage>(true);
        gameManager = FindObjectOfType<GameManagerSpace>(true);
        poolManager = FindObjectOfType<PoolManager>(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        ply = FindObjectOfType<SpacePly>(true);
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        Vector2 dis = (ply.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(dis * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if (isDamaged) return;
            StartCoroutine(Damaged());
            collision.gameObject.transform.SetParent(poolManager.transform);
            collision.gameObject.SetActive(false);
            if (hp < 0)
            {
                gameManager.downcount();
                BoomSpawn();
                gameObject.SetActive(false);
            }
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!gameObject.activeSelf) return;
            gameManager.hpdowncount();
        }
    }

    private IEnumerator Damaged()
    {
        if (!isDamaged)
        {
            isDamaged = true;
            hp--;
            spriteRenderer.color = Color.red;
            yield return dely;
            spriteRenderer.color = Color.white;
            isDamaged = false;
        }
    }

    private void BoomSpawn()
    {
        GameObject boom;
        if (boomManager.transform.childCount > 0)
        {
            boom = boomManager.transform.GetChild(0).gameObject;
        }
        else
        {
            boom = Instantiate(boomprefeb, transform.position, Quaternion.identity);
        }
        boom.transform.position = transform.position;
        boom.SetActive(true);
        boom.transform.SetParent(null);
    }
}
