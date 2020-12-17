using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    public void LoadNextLevel()
    {
        StartCoroutine(LevelLoad(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLastLevel()
    {
        StartCoroutine(LevelLoad(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LevelLoad(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
