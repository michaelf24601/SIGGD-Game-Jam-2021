using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public SpriteRenderer officeDude;
    public SpriteRenderer officeDudeFalling;
    public SpriteRenderer officeDudeDead;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            officeDude.enabled = false;
            officeDudeFalling.enabled = true;
        } else
        {
            officeDude.enabled = true;
            officeDudeFalling.enabled = false;
        }
    }

    public void Die()
    {
        officeDude.enabled = false;
        officeDudeFalling.enabled = false;
        officeDudeDead.enabled = true;
        this.enabled = false;
    }
}
