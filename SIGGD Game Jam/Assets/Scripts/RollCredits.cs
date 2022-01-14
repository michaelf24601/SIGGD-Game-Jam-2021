using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    private float creditsSpeed = 20f;
    float timePassed = 0.0f;
    bool rollCredits = false;
    // Update is called once per frame
    void Update()
    {
        if (rollCredits)
        {
            transform.Translate(Vector3.up * creditsSpeed * Time.deltaTime);
            timePassed += Time.deltaTime;
            if (timePassed > 74f)
            {
                Application.Quit();
            }
        }
    }
    public void roll()
    {
        rollCredits = true;
    }

}
