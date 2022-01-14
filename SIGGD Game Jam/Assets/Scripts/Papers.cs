using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papers : Platform
{
    public override void JumpBehavior(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0) //if colliding from the top direction
        {
            FindObjectOfType<AudioManager>().Play("Papers");
            GameObject.Destroy(this.gameObject);
        }
    }
}
