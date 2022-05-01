using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [SerializeField] private Constants.AlienTypes PlanetType;
    [SerializeField] private Constants.PlanetNames PlanetName;
    [SerializeField] private List<Planet> ConnectedPlanets;
    [SerializeField] private string SceneName;

    void connectPlanet(Planet linkedPlanet) {
        ConnectedPlanets.Add(linkedPlanet);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlanetType = (Constants.AlienTypes) Random.Range(0f, Constants.AlienTypesLength - 1.0f);
        PlanetName = (Constants.PlanetNames) Random.Range(0f, Constants.PlanetNamesLength - 1.0f);
    }

    private void OnMouseDown()
    {

        Comp_MenuAudio audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Comp_MenuAudio>();

        audioManager.ButtonSFX();
        audioManager.MenuMusicStop();

        switch (gameObject.GetComponentInParent<Tier>().tier)
        {
            case 1:
                audioManager.Stage1MusicPlay();
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._engine.SetActive(true);
                break;
            case 2:
                audioManager.PitStopMusicStart();
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._engine.SetActive(false);
                break;
            case 3:
                audioManager.Stage2MusicPlay();
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._engine.SetActive(true);
                break;
            default:
                break;
        }

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().difficulty = gameObject.GetComponentInParent<Tier>().Difficulty;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().tier = gameObject.GetComponentInParent<Tier>().tier + 1;
        SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
