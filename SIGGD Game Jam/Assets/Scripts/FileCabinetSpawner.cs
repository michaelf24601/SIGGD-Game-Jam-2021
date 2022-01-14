using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabinetSpawner : MonoBehaviour
{
    public GameObject fileCabinet;
    public Transform player;
    public int chanceToSpawn = 10;
    public int maxSpawn = 1;

    // Start is called before the first frame update
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
            if (GameObject.FindGameObjectsWithTag("Cabinet").Length > maxSpawn - 1)
            {
                return;
            }
            int rand = Random.Range(1, 101);
            if (rand <= chanceToSpawn)
            {
                Vector3 spawnPos = new Vector3(player.position.x, player.position.y + StateManager.GAME_HEIGHT, 0);
                Instantiate(fileCabinet, spawnPos, Quaternion.identity);
            }
        } catch (MissingReferenceException)
        {
            this.enabled = false;
        }
    }
}
