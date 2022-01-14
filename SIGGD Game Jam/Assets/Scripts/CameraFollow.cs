using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothSpeed = .3f;
    public float yOffset = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        try
        {
            if (StateManager.GAME_IS_OVER)
            {
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
                return;
            }
            if (target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
            }
        } catch (MissingReferenceException)
        {
            this.enabled = false;
        }
    }
}
