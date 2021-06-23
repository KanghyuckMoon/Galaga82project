using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOvermanager : MonoBehaviour
{
    [SerializeField]
    private Text scoretext;
    [SerializeField]
    private Text sumscoretext;
    [SerializeField]
    private Text grade;
    [SerializeField]
    private Text grade2;

    [SerializeField]
    private int dan = 0;
    void Start()
    {
       
        scoretext.text = string.Format("");
        StartCoroutine(RollingNumber());
        if (PlayerPrefs.GetInt("SUMSCORE") > PlayerPrefs.GetInt("MAXSUMSCORE", 0))
        {
            PlayerPrefs.SetInt("MAXSUMSCORE", PlayerPrefs.GetInt("SUMSCORE"));
        }
        if (PlayerPrefs.GetInt("HIGHSCORE") > PlayerPrefs.GetInt("MAXHIGHSCORE", 0))
        {
            PlayerPrefs.SetInt("MAXHIGHSCORE", PlayerPrefs.GetInt("HIGHSCORE"));
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
        int target = PlayerPrefs.GetInt("SUMSCORE");
        float forscore = target / 82;
        WaitForSeconds dely = new WaitForSeconds(0.05f);

        while (current < target)
        {
            if (dan > 0) break;
            current += forscore;

            sumscoretext.text = string.Format("-SUMSCORE-\n{0}", (int)current);


            yield return dely;
        }
        dan = 1;
        sumscoretext.text = string.Format("-SUMSCORE-\n{0}", PlayerPrefs.GetInt("SUMSCORE"));
        current = PlayerPrefs.GetInt("SUMSCORE");
        if (current > 10000) grade.text = string.Format("A");
        else if (current > 8000) grade.text = string.Format("B");
        else if (current > 5000) grade.text = string.Format("C");
        else grade.text = string.Format("D");
        grade.gameObject.SetActive(true);
        yield return dely;
        current = 0;
        int highscore = PlayerPrefs.GetInt("HIGHSCORE");
        while (current < highscore)
        {
            if (dan > 1) break;
            current += 1;

            scoretext.text = string.Format("-HIGHSCORE-\n{0}", current);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("asd2");
                break;
            }

            yield return null;

        }
        dan = 2;
        current = highscore;
        scoretext.text = string.Format("-HIGHSCORE-\n{0}", highscore);
        if (current > 600) grade2.text = string.Format("A");
        else if (current > 400) grade2.text = string.Format("B");
        else if (current > 200) grade2.text = string.Format("C");
        else grade2.text = string.Format("D");
        grade2.gameObject.SetActive(true);
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
