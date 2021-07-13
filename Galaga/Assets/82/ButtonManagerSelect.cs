using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManagerSelect : MonoSingleTon<ButtonManagerSelect>
{
    [SerializeField]
    private GameObject MainImages;
    [SerializeField]
    private GameObject[] Images;

    [SerializeField]
    private TextMeshProUGUI[] scoretexts;

    private void Start()
    {
        scoretexts[0].text = string.Format("SumBest\n{0}\nHighBest\n{1}", PlayerPrefs.GetInt("MAXSUMSCORE",0), PlayerPrefs.GetInt("MAXHIGHSCORE", 0));
        scoretexts[1].text = string.Format("Best\n{0}", PlayerPrefs.GetInt("MAXSprCount", 0));
        scoretexts[2].text = string.Format("Best\n{0}", PlayerPrefs.GetInt("MAXKillCount", 0));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OpenGuide(int num)
    {
        MainImages.SetActive(true);
        for (int i = 0; i < MainImages.transform.childCount;i++)
        {
            MainImages.transform.GetChild(i).gameObject.SetActive(false);
        }
        Images[num].SetActive(true);
    }

    public void CloseGuide()
    {
        for (int i = 0; i < MainImages.transform.childCount; i++)
        {
            MainImages.transform.GetChild(i).gameObject.SetActive(false);
        }
        MainImages.SetActive(false);
    }

    public void Move82()
    {
        SceneManager.LoadScene("InGame");
    }
    public void MoveSpace()
    {
        SceneManager.LoadScene("Space");
    }
    public void MoveInvader()
    {
        SceneManager.LoadScene("Invader");
    }
}
