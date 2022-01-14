using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject briefcasePrefab;
    public GameObject papersPrefab;
    public int levelHeight = 100;
    public float gravity = 15f;
    public float minY = .2f;
    public float maxY = 1.5f;

    private float playerSpeed;
    

    private void Start()
    {
        playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speed;

        Vector3 spawnPos = Vector3.zero;
        for (float y = 0; y < levelHeight; y += Random.Range(minY, maxY))
        {
            spawnPos.y = y;
            if (y == 0)
            {
                //where to put the first platform
                spawnPos.x = 0;
                Instantiate(briefcasePrefab, spawnPos, Quaternion.identity);
                continue;
            }

            spawnPos.x = Random.Range(-StateManager.GAME_WIDTH/2f + 0.5f, StateManager.GAME_WIDTH/2f - 0.5f);

            int rand = Random.Range(1, 101);

            //probability of spawning different types of platforms 

            if (y > levelHeight / 5) 
            {
                if (rand > 85)
                {
                    Instantiate(papersPrefab, spawnPos, Quaternion.identity);
                    continue;
                }
            }

            Instantiate(briefcasePrefab, spawnPos, Quaternion.identity);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 bl = new Vector3(-StateManager.GAME_WIDTH/2, 0, 0);
        Vector3 br = new Vector3(StateManager.GAME_WIDTH / 2, 0, 0);
        Vector3 tl = new Vector3(-StateManager.GAME_WIDTH / 2, levelHeight, 0);
        Vector3 tr = new Vector3(StateManager.GAME_WIDTH / 2, levelHeight, 0);

        Gizmos.DrawLine(bl, br);
        Gizmos.DrawLine(bl, tl);
        Gizmos.DrawLine(br, tr);
        Gizmos.DrawLine(tl, tr);
    }
}
