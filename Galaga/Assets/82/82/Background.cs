using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Vector2 offset;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {  
        offset.y += 0.5f * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex",offset);
    }
}
