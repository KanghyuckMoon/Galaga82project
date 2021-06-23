using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    Text text;
    void Awake()
    {
        Time.timeScale = 0f;
        text = GetComponent<Text>();
        StartCoroutine(CountDownCorutine());
    }

    private IEnumerator CountDownCorutine()
    {
        WaitForSecondsRealtime dely = new WaitForSecondsRealtime(1);
        text.text = string.Format("3");
        yield return dely;
        text.text = string.Format("2");
        yield return dely;
        text.text = string.Format("1");
        yield return dely;
        text.text = string.Format("GO");
        yield return dely;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

}
