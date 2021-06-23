using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameINVALManager : MonoBehaviour
{
    [SerializeField]
    private Text sumscoretext;
    [SerializeField]
    private Text grade;

    [SerializeField]
    private int dan = 0;
    void Start()
    {
        StartCoroutine(RollingNumber());
        if(PlayerPrefs.GetInt("KillCount") > PlayerPrefs.GetInt("MAXKillCount", 0))
        {
            PlayerPrefs.SetInt("MAXKillCount", PlayerPrefs.GetInt("KillCount"));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dan++;
        }
    }

    private IEnumerator RollingNumber()
    {
        float current = 0f;
        int target = PlayerPrefs.GetInt("KillCount");
        float forscore = target / 82;
        WaitForSeconds dely = new WaitForSeconds(0.05f);

        while (current < target)
        {
            if (dan > 0) break;
            current += 1;

            sumscoretext.text = string.Format("-EnemyCount-\n{0}", (int)current);


            yield return dely;
        }
        dan = 1;
        current = PlayerPrefs.GetInt("KillCount");
        sumscoretext.text = string.Format("-KillCount-\n{0}", PlayerPrefs.GetInt("KillCount"));
        if (current > 500) grade.text = string.Format("A");
        else if (current > 300) grade.text = string.Format("B");
        else if (current > 100) grade.text = string.Format("C");
        else grade.text = string.Format("D");
        yield return dely;
        grade.gameObject.SetActive(true);
        yield return dely;
        dan = 2;
        yield return dely;
        while (true)
        {
            if (dan > 2) break;
            yield return null;
        }
        SceneManager.LoadScene("Main");
        yield return null;
    }

}
