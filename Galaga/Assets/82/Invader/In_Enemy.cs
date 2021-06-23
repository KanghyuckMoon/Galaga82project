using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Enemy : MonoBehaviour
{
    protected SpacePly ply;
    protected Rigidbody2D rigid;
    [SerializeField]
    protected int orhp;
    [SerializeField]
    protected int hp;
    protected InvaderGameManager gameManager;
    [SerializeField]
    protected float speed = 15f;
    protected PoolManager poolManager;
    protected SpriteRenderer spriteRenderer;
    protected WaitForSeconds dely = new WaitForSeconds(0.1f);
    public bool isDamaged;
    private BoomManage boomManager;
    [SerializeField]
    private GameObject boomprefeb;
    [SerializeField]
    private EnemyPool enemyPool;

    private void Awake()
    {
        enemyPool = FindObjectOfType<EnemyPool>(true);
        boomManager = FindObjectOfType<BoomManage>(true);
        gameManager = FindObjectOfType<InvaderGameManager>(true);
        poolManager = FindObjectOfType<PoolManager>(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        ply = FindObjectOfType<SpacePly>(true);
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        isDamaged = false;
        hp = orhp;
        spriteRenderer.color = Color.white;
    }

    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (isDamaged) return;
            StartCoroutine(Damaged());
            if (hp < 0)
            {
                gameManager.downcount();
                BoomSpawn();
                transform.SetParent(enemyPool.transform);
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gameObject.activeSelf) return;
            gameManager.GameEnd();
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
