using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool start;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (start) return;
            start = true;
            anim.Play("titlestart");
            Invoke("Startgame", 0.62f);
        }
    }

    private void Startgame()
    {

        SceneManager.LoadScene("SelectScene");
    }
}
