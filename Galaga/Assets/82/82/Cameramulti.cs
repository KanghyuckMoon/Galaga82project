using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cameramulti : MonoBehaviour
{
    [SerializeField]
    GameObject plane;
    [SerializeField]
    GameObject playerparant;
    [SerializeField]
    List<GameObject> planesons;
    [SerializeField]
    public List<GameObject> players;
    [SerializeField]
    List<int> scores;
    [SerializeField]
    List<TextMesh> texts;
    [SerializeField]
    private int random;
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private int highscore = 0;
    [SerializeField]
    private int sumscore = 0;
    Camera cam;
    [SerializeField]
    private BaseCam baseCam;

    [SerializeField]
    private TextMesh lifetext; // 목숨
    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.cullingMask = ~(1 << 10);
        for (int i = 0; i < plane.transform.childCount; i++)
        {
            planesons.Add(plane.transform.GetChild(i).gameObject);
            texts.Add(planesons[i].GetComponentInChildren<TextMesh>());
            scores.Add(10);
        }
        for (int i = 0; i < playerparant.transform.childCount; i++)
        {
            players.Add(playerparant.transform.GetChild(i).gameObject);
        }
        transform.position = plane.transform.GetChild(0).transform.position;
        plane.transform.GetChild(random).GetComponent<SpriteRenderer>().color = Color.yellow;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    public void NextCamera(GameObject obj)
    {
        if(planesons.Count == 1)
        {
            for(int i = 0; i < scores.Count;i++)
            {
                if (highscore < scores[i]) highscore = scores[i];
                sumscore += scores[i];
            }
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
            PlayerPrefs.SetInt("SUMSCORE", sumscore);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            planesons[players.IndexOf(obj)].GetComponent<SpriteRenderer>().color = Color.black;
            planesons.RemoveAt(players.IndexOf(obj));
            players.Remove(obj);
            lifetext.text = string.Format("X {0}", players.Count);
            transform.position = planesons[0].transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            planesons[0].GetComponent<SpriteRenderer>().color = Color.yellow;
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.transform.position = new Vector3(lineRenderer.transform.position.x, lineRenderer.transform.position.y, 1);
        }
        baseCam.jindong();
    }

    public void AddScoreCam(int i)
    {
        scores[i] += 10;
        texts[i].text = string.Format("{0}", scores[i]); 
    }
}
