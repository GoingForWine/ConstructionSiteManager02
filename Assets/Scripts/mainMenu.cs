using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToOffice()
    {
        SceneManager.LoadScene("Office_Scene");
    }

    public void GoToSite()
    {
        SceneManager.LoadScene("Site_Scene");
    }

    public void GoToInteraction()
    {
        SceneManager.LoadScene("Interaction_Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quitted");
        Application.Quit();
    }
}
