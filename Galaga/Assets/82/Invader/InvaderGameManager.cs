using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InvaderGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemys;
    [SerializeField]
    private GameObject enemypool;
    [SerializeField]
    private Text enemycountext;
    protected Spr_Cam cam;
    protected WaitForSeconds dely = new WaitForSeconds(0.1f);


    private int killenenmy;

    public void downcount()
    {
        killenenmy++;
        cam.Shakecam(0.4f, 0.2f);
        UpdateUI();
    }

    private void Start()
    {
        cam = FindObjectOfType<Spr_Cam>(true);
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        while(true)
        {
            Pool();
            yield return dely;
        }
    }

    private void Pool()
    {
        float randomx = Random.Range(-8f, 8f);
        int randomobj = Random.Range(0, Enemys.Length);
        GameObject enemy;
        if (enemypool.transform.childCount > 0)
        {
            enemy = enemypool.transform.GetChild(0).gameObject;
            enemy.transform.position = new Vector2(randomx, 8f);
            enemy.transform.SetParent(null);
            enemy.SetActive(true);
        }
        else
        {
            enemy = Instantiate(Enemys[randomobj],new Vector2(randomx,8f), Quaternion.identity);
        }
        enemy.transform.SetParent(null);
    }

    public void GameEnd()
    {
        PlayerPrefs.SetInt("KillCount", killenenmy);
        SceneManager.LoadScene("In_End");
    }

    private void UpdateUI()
    {
        enemycountext.text = string.Format("Enemy Count : {0}", killenenmy);
    }
}
