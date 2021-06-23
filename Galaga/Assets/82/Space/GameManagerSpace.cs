using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerSpace : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemys;
    [SerializeField]
    private GameObject poolmanager;
    protected WaitForSeconds dely = new WaitForSeconds(0.1f);
    protected Spr_Cam cam;
    [SerializeField]
    private Text enemycountext;
    [SerializeField]
    private Text lifecountext;

    private int Enemycount = 82;
    private int hp = 3;
    public bool isdamaged;

    private void Start()
    {
        cam = FindObjectOfType<Spr_Cam>(true);
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i<82;i++)
        {
            float randomx = Random.Range(-44f,44f);
            float randomy = Random.Range(-44f, 44f);
            int randomobj = Random.Range(0, Enemys.Length);
            Instantiate(Enemys[randomobj], new Vector2(randomx,randomy), transform.rotation);
            yield return dely;
        }
    }

    public void downcount()
    {
        Enemycount--;
        UpdateUI();
        if(Enemycount <= 0)
        {
            GameEnd();
        }
    }

    public void hpdowncount()
    {
            hp--;
            cam.Shakecam(5f, 0.2f);
            if (hp <= 0)
            {
                GameEnd();
            }
        UpdateUI();
    }

    public void GameEnd()
    {
        PlayerPrefs.SetInt("SprCount", Enemycount);
        SceneManager.LoadScene("Spr_End");
    }

    private void UpdateUI()
    {
        enemycountext.text = string.Format("Enemy Count : {0}",Enemycount);
        lifecountext.text = string.Format("Life : {0}", hp);
    }
}
