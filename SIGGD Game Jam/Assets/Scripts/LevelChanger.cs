using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("Active scene is scene 1");
            animator.SetTrigger("FadeIn");
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        Debug.Log("Fade to level: " + levelIndex);
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
