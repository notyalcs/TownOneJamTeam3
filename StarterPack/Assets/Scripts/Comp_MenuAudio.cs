using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_MenuAudio : MonoBehaviour
{

    [Header("Music")]
    [SerializeField] private AudioSource _menuMusic;
    [SerializeField] private AudioSource _stage1Music;
    [SerializeField] private AudioSource _stage2Music;
    [SerializeField] private AudioSource _pitStopMusic;

    [Header("Buttons")]
    [SerializeField] private AudioSource _buttonSFX;

    [Header("SFX")]
    [SerializeField] private AudioSource _spawnSFX;
    [SerializeField] private AudioSource _spawnSlarkSFX;

    private void Awake()
    {
        var audio = GameObject.FindGameObjectsWithTag("AudioManager");

        if (audio.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        MenuMusicStart();
    }

    public void CreditsSceneStart() {
        _menuMusic.Stop();
        _stage1Music.Stop();
        _stage2Music.Stop();
        _pitStopMusic.Stop();

        _pitStopMusic.Play();
    }

    public void MenuMusicStart()
    {
        _menuMusic.Stop();
        _stage1Music.Stop();
        _stage2Music.Stop();
        _pitStopMusic.Stop();

        _menuMusic.Play();
    }
    public void MenuMusicStop()
    {
        _menuMusic.Stop();
    }

    public void Stage1MusicPlay()
    {
        _stage1Music.Play();
    }
    public void Stage1MusicStop()
    {
        _stage1Music.Stop();
    }

    public void Stage2MusicPlay()
    {
        _stage2Music.Play();
    }
    public void Stage2MusicStop()
    {
        _stage2Music.Stop();
    }

    public void PitStopMusicStart()
    {
        _pitStopMusic.Play();
    }
    public void PitStopMusicStop()
    {
        _pitStopMusic.Stop();
    }

    public void ButtonSFX()
    {
        _buttonSFX.Play();
    }
    public void SpawnSFX()
    {
        _spawnSFX.Play();
    }
    public void SpawnSlarkSFX()
    {
        _spawnSlarkSFX.Play();
    }
}
