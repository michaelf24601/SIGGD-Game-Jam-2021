using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float speed = 7f;
    private bool dead = false;
    Rigidbody2D rb;
    float movement = 0f;
    Transform camera;
    bool GodMode = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("g") && Input.GetKey("m"))
        {
            GodMode = true;
            Debug.Log("GOD MODE!");
        }
        if (!StateManager.GAME_START)
        {
            return;
        }
        if (!dead)
        {
            movement = Input.GetAxis("Horizontal");
        }
        else
        {
            //if in view of camera then go down. return so nothing else executes b/c i like being nice to my cpu ;)
            if (transform.position.y > camera.position.y - StateManager.GAME_HEIGHT)
            {
                transform.Translate(Vector3.down * 15f * Time.deltaTime);
            }
            return;
        }

        if (transform.position.y < camera.position.y - StateManager.GAME_HEIGHT / 2)
        {
            Die();
        }
        if (Mathf.Abs(transform.position.x) > StateManager.GAME_WIDTH/2)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }

    }

    private void FixedUpdate()
    {
        if (!dead && StateManager.GAME_START)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movement * speed;
            rb.velocity = velocity;
        }
    }

    public void Die()
    {
        if (GodMode)
        {
            return;
        }
        if (dead) { return; }
        FindObjectOfType<AudioManager>().Stop("Ambient");
        gameObject.GetComponent<PlayerAnimation>().Die();
        GameObject.FindGameObjectWithTag("ObstacleCollider").SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.isKinematic = true;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        dead = true;
        StateManager.GAME_IS_OVER = true;
        StartCoroutine("Fall");
    }

    IEnumerator Fall ()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        float clipLength = audioManager.getClipLength("PlayerFalling");
        audioManager.Play("PlayerFalling");
        yield return new WaitForSeconds(clipLength);
        camera.gameObject.GetComponent<CameraFollow>().enabled = false;
        yield return new WaitForSeconds(1f);
        FindObjectOfType<StateManager>().GameOver();
    }

}
