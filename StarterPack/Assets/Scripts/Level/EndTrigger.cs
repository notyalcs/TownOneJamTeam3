using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public bool IsLevelOver { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train"))
        {
            IsLevelOver = true;
            StartCoroutine(RideIntoTheSun());
        }
    }

    private IEnumerator RideIntoTheSun()
    {
        //float time = 0f;
        //while (time < Constants.WaitTime)
        //{
        //    time += Time.deltaTime;
        //}

        yield return new WaitForSeconds(Constants.WaitTime);

        var audio = GameObject.FindGameObjectWithTag("AudioManager");
        var gm = GameObject.FindGameObjectWithTag("GameManager");

        if (gm.GetComponent<GameManager>().tier == 2)
        {
            audio.GetComponent<Comp_MenuAudio>().Stage1MusicStop();
            audio.GetComponent<Comp_MenuAudio>().MenuMusicStart();
        } 
        else
        {
            audio.GetComponent<Comp_MenuAudio>().Stage2MusicStop();
            audio.GetComponent<Comp_MenuAudio>().MenuMusicStart();
        }

        SceneManager.LoadScene("Demo Starmap");
    }
}
