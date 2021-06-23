using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spr_BeeEnemy : Spr_NormalEnemy
{
    private bool move = false;
    private Vector2 plypos;
    protected override void Update()
    {
        if (Vector2.Distance(ply.transform.position, transform.position) > 8) return;
        if ((Vector2)transform.position == plypos) move = false;
        if(move == false)
        {
            plypos = ply.transform.position;
            Vector2 dis = (ply.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.DOMove(plypos,2f);
            move = true;
        }
    }
}
