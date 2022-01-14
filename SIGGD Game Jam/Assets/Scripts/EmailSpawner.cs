using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailSpawner : MonoBehaviour
{

    public int chanceToSpawn = 10;
    public int maxSpawn = 2;
    public int verticalOffset = 5;
    public Transform player;
    public GameObject email;

    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 1.0f);
    }

    void Spawn()
    {
        if (!StateManager.GAME_START)
        {
            return;
        }
        try
        {
            if (GameObject.FindGameObjectsWithTag("Email").Length > maxSpawn - 1)
            {
                return;
            }

            int rand = Random.Range(1, 101);
            if (rand <= chanceToSpawn)
            {
                Vector3 spawnPos = new Vector3(StateManager.GAME_WIDTH/2 + 1, player.position.y + verticalOffset, 0);
                if (Mathf.Abs(spawnPos.x - player.position.x) < StateManager.GAME_WIDTH / 2 + 1)
                {
                    spawnPos.x *= -1;
                }
                Instantiate(email, spawnPos, Quaternion.identity);
            }
        } catch (MissingReferenceException)
        {
            this.enabled = false;
        }
    }
}
