using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSceneAnimation : MonoBehaviour
{
    public GameObject mkd;
    public GameObject mk;
    public GameObject player;
    public GameObject credits;

    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine("doAnimation");
    }

    IEnumerator doAnimation ()
    {
        player.GetComponent<Animator>().SetTrigger("Play");
        yield return new WaitForSeconds(4f);
        player.GetComponent<Animator>().enabled = false;
        player.transform.position = new Vector3(0.732f, -0.069f, 0);
        yield return new WaitForSeconds(1f); //delay before hold hands
        mkd.SetActive(true);
        player.SetActive(false);
        mk.SetActive(false);
        yield return new WaitForSeconds(3f);
        Debug.Log("Roll Credits");
        credits.GetComponent<RollCredits>().roll();
        
    }

    IEnumerator LerpPosition(GameObject obj, Vector3 targetPosition, float duration)
    {
        float time = 0;
        RectTransform rt = obj.GetComponent<RectTransform>();
        Vector3 startPosition = rt.position;

        while (time < duration)
        {
            rt.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPosition; //correct for small inaccuracies with lerp function
    }


}
