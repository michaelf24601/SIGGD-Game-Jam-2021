using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public static float JUMP_FORCE = 15f;

    private Transform camera;
    private AudioManager audioManager;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (transform.position.y < camera.transform.position.y - StateManager.GAME_HEIGHT/2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            return;
        }

        JumpBehavior(collision);
    }

    public virtual void JumpBehavior(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0) //if colliding from the top direction
        {
            audioManager.Play("Jump");
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 velocity = rb.velocity;
            velocity.y = JUMP_FORCE;
            rb.velocity = velocity;
        }
    }
}
