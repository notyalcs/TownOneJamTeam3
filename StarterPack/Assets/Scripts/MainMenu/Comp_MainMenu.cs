using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comp_MainMenu : MonoBehaviour
{

    public void StartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton() {
        Debug.Log("quit");
        Application.Quit();
    }

}
