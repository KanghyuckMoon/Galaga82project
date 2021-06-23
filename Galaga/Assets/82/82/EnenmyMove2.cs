using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyMove2 : EnenmyMove1
{
    protected override void Update()
    {
        transform.Translate(Vector2.down * (speed + (0.1f * hp)) * Time.deltaTime);
        if (transform.position.y < -4.4f) Disableanim();
    }
}
