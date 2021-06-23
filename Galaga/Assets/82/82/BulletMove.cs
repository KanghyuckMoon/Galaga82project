using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    GameObject playerparant;
    [SerializeField]
    List<GameObject> players;
    [SerializeField]
    List<GameObject> bullets;
    [SerializeField]
    private GameObject poolManager;
    [SerializeField]
    private Cameramulti maincamera;

    private void Awake()
    {
        for (int i = 0; i < playerparant.transform.childCount; i++)
        {
            players.Add(playerparant.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            bullets.Add(transform.GetChild(i).gameObject);
        }
        poolManager = transform.parent.gameObject;
    }
    private void OnEnable()
    {
        for (int i = 0; i < playerparant.transform.childCount; i++)
        {
            if(bullets[i].activeSelf)
            {
                if (!playerparant.transform.GetChild(i).gameObject.activeSelf)
                {
                    bullets[i].gameObject.SetActive(false);
                }
            }
        }
        Invoke("Disable", 1f);
    }
    protected virtual void Update()
    {
        transform.Translate(Vector2.up * 1 * Time.deltaTime);
    }

    public void Disable()
    {
        transform.SetParent(poolManager.transform, false);
        gameObject.SetActive(false);
    }

    public void AddScore(GameObject bulletobj)
    {
        maincamera.AddScoreCam(bullets.IndexOf(bulletobj));
    }
}
