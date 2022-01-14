using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingAnimation : MonoBehaviour
{
    public TextMeshProUGUI expositionText;
    public GameObject levelChanger;
    private int dialogueState = -1;
    private AudioManager audioManager;
    private string[] dialogue =
    {
        "I can't take it anymore!",
        "All the pressure I'm under at work!",
        "All the stress I'm under in my life!",
        "All the debt I'm under, all the expectations I'm under - It's suffocating!",
        "I'm being crushed under the invisible hand of capitalism!",
        "I need to escape!"
    };
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        audioManager.Play("Office");
        Invoke("hideLevelChanger", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //maybe on spacebar down later
        {
            dialogueState++;
            if (dialogueState == dialogue.Length)
            {
                StateManager.GAME_START = true;
                GameObject expositionCanvas = GameObject.FindGameObjectWithTag("expositionCanvas");
                GameObject.Destroy(expositionCanvas);
                audioManager.Play("Jump");
                rb.isKinematic = false;
                rb.velocity = new Vector3(0,20,0);
                audioManager.Stop("Office");
                audioManager.Play("GlassShatter");
                audioManager.Play("Ambient");
                GameObject.Destroy(this.gameObject);
                return;
            }
            expositionText.text = dialogue[dialogueState] + "\n(press space)";
        }
    }

    private void hideLevelChanger()
    {
        levelChanger.SetActive(false);
    }
}
