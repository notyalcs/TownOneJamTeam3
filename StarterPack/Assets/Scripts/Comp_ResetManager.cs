using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_ResetManager : MonoBehaviour
{
    private void Start() {
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));


        Comp_MenuAudio audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Comp_MenuAudio>();
        audioManager.CreditsSceneStart();
    }
}
