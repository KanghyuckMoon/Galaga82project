using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
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
        if (PlayerPrefs.GetInt("SprCount") < PlayerPrefs.GetInt("MAXSprCount", 82))
        {
            PlayerPrefs.SetInt("MAXSprCount", PlayerPrefs.GetInt("SprCount"));
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
        int target = PlayerPrefs.GetInt("SprCount");
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
        current = PlayerPrefs.GetInt("SprCount");
        sumscoretext.text = string.Format("-EnemyCount-\n{0}", PlayerPrefs.GetInt("SprCount"));
        if (current > 70) grade.text = string.Format("D");
        else if (current > 40) grade.text = string.Format("C");
        else if (current > 10) grade.text = string.Format("B");
        else grade.text = string.Format("A");
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
