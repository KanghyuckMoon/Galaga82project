using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spr_GalagaEnemy : Spr_NormalEnemy
{
    private float timer = 10f;
    private int ran;
    protected override void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ran = Random.Range(-90, 90);
            timer = 10f;
        }
        Vector2 dis = (ply.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + ran, Vector3.forward);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }
}
