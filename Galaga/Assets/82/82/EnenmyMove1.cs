using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyMove1 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemypool;
    [SerializeField]
    private Cameramulti maincamera;
    [SerializeField]
    protected int hp = 1;
    [SerializeField]
    private int maxhp = 1;

    private Animator anim;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private Color white = new Color(1f, 1f, 1f, 1f);
    [SerializeField]
    private Color StartColor = new Color(1f, 1f, 1f, 1f);
    [SerializeField]
    private GameObject boomManager;
    [SerializeField]
    private GameObject boomprefeb;
    [SerializeField]
    protected float speed = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        hp = maxhp;
        spriteRenderer.color = StartColor;
        speed = 3f - maincamera.players.Count * 0.03f;
    }
    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -4.4f) Disableanim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            maincamera.NextCamera(collision.gameObject);
            collision.gameObject.SetActive(false);
            BoomSpawn();
        }
        if(collision.CompareTag("Bullet"))
        {
            collision.transform.parent.GetComponent<BulletMove>().AddScore(collision.gameObject);
            hp--;
            if (hp == 1)
            {
                spriteRenderer.color = white;
            }
            else if (hp <= 0)
            {
                Disable();
            }
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
    private void Disable()
    {
        anim.Play("pop");
        col.enabled = false;
    }
    public void Disableanim()
    {
        transform.SetParent(enemypool.transform);
        gameObject.SetActive(false);
    }
}
