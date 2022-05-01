using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitStopMenuController : MonoBehaviour
{
    public void IncreaseHealth()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._engine.SetActive(true);
        GameObject.FindGameObjectWithTag("Train").GetComponent<Comp_UnitInfo>().Health += 50;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._engine.SetActive(false);

        var audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Comp_MenuAudio>();
        audio.PitStopMusicStop();
        audio.ButtonSFX();
        audio.MenuMusicStart();

        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Demo Starmap");
    }

}
