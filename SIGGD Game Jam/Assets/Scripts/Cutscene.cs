using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cutscene : MonoBehaviour
{
    private AudioManager audioManager;

    public Transform everything;
    public Transform computer;
    public Transform clock;
    public Transform picture;

    public GameObject menu;
    public GameObject email;
    public GameObject emailText;
    public GameObject word;
    public GameObject wordText;
    public GameObject notification;
    public GameObject cursor;
    public GameObject screenTextPannel;
    public GameObject typePrompt;

    public GameObject levelChanger;
    public GameObject clockText;

    private bool typing = false;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    private void Update()
    {

    }

    public void start()
    {
        levelChanger.SetActive(true);
        StartCoroutine("startAnimation");
    }

    IEnumerator startAnimation()
    {
        menu.SetActive(false);
        screenTextPannel.SetActive(true);
        StartCoroutine(LerpPosition(this.gameObject, computer.position, 2f));
        yield return new WaitForSeconds(2f);
        Debug.Log("at computer");

        Debug.Log("Start typing stuff plz");
        typePrompt.SetActive(true);
        wordText.SetActive(true);
        string firstThingToType = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed et neque auctor, lobortis justo a, semper ligula. Cras ex dolor, dapibus ac varius sed, dapibus in tellus. Aliquam maximus egestas eros, non pretium mauris ultrices a.";
        StartCoroutine(TypeStuff(firstThingToType));
        typing = true;
        while (typing)
        {
            yield return new WaitForSeconds(1f);
        }
        typePrompt.SetActive(false);
        yield return new WaitForSeconds(1f);

        StartCoroutine(LerpPosition(this.gameObject, clock.position, 2f));
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        StartCoroutine(LerpPosition(this.gameObject, picture.position, 4f));
        yield return new WaitForSeconds(4f);
        yield return new WaitForSeconds(2f);
        StartCoroutine(LerpPosition(this.gameObject, computer.position, 2f));
        yield return new WaitForSeconds(2f);

        clockText.GetComponent<TextMeshProUGUI>().text = "4:59";

        string secondThingToType = "Sed finibus enim tellus, ac consectetur arcu viverra ut. Vivamus pulvinar auctor tincidunt. Maecenas dictum bibendum pharetra. Duis fermentum sapien velit, a convallis nunc rhoncus quis. Vestibulum feugiat dapibus risus id porta.";
        typePrompt.SetActive(true);
        StartCoroutine(TypeStuff(secondThingToType));
        typing = true;
        while (typing)
        {
            yield return new WaitForSeconds(1f);
        }
        typePrompt.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(LerpPosition(this.gameObject, clock.position, 2f));
        yield return new WaitForSeconds(2f);
        audioManager.Play("Notification");
        notification.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LerpPosition(this.gameObject, computer.position, 2f));
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LerpPosition(cursor, new Vector3(6.2f,-12.2f,0), 2f));
        yield return new WaitForSeconds(2f);
        audioManager.Play("MouseClick");
        notification.SetActive(false);
        wordText.SetActive(false);
        email.SetActive(true);
        emailText.SetActive(true); 
        yield return new WaitForSeconds(16f); //EMAIL WAIT TIME
        StartCoroutine(LerpPosition(this.gameObject, picture.transform.position, 3f));
        yield return new WaitForSeconds(2f);

        levelChanger.GetComponent<LevelChanger>().FadeToLevel(1);

    }

    public void quit()
    {
        Application.Quit();
    }

    IEnumerator LerpPosition(GameObject obj, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = obj.transform.position;

        while (time < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPosition; //correct for small inaccuracies with lerp function
    }

    IEnumerator TypeStuff(string text)
    {
        int index = 0;

        while (index < text.Length)
        {
            if (Input.anyKey)
            {
                wordText.GetComponent<TextMeshProUGUI>().text += text[index];
                index++;
            }
            yield return null;
        }
        typing = false;
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
