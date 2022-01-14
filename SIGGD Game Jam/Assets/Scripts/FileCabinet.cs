using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabinet : MonoBehaviour
{
    public float fallSpeed = 2f; 
    private Transform camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < camera.position.y - StateManager.GAME_HEIGHT / 2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ObstacleCollider"))
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        FindObjectOfType<AudioManager>().Play("FileCabinetSlam");
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.Die(); 
    }
}
