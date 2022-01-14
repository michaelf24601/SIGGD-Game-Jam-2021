using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : MonoBehaviour
{
    private Transform player; //for some reason assigning this publicly is not working
    public float  moveSpeed = 5f;
    public float rotationSpeed = 1f;
    private Transform camera; //same problem

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = Vector3.zero;
        try
        {
            dirToPlayer = player.position - transform.position;
        } catch (MissingReferenceException)
        {
            GameObject.Destroy(this.gameObject);
        }
        Debug.DrawRay(transform.position, dirToPlayer, Color.blue);
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.up, dirToPlayer, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        Quaternion rot = new Quaternion();
        rot.SetLookRotation(transform.forward, newDirection);
        transform.rotation = rot;

        transform.position += transform.up * moveSpeed * Time.deltaTime;

        if (transform.position.y < camera.position.y - StateManager.GAME_HEIGHT/2)
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
        FindObjectOfType<AudioManager>().Play("PaperCut");
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.Die();
        GameObject.Destroy(this.gameObject);
    }
}
