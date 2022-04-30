using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [SerializeField] private Constants.AlienTypes PlanetType;
    [SerializeField] private Constants.PlanetNames PlanetName;
    [SerializeField] private List<Planet> ConnectedPlanets;

    void connectPlanet(Planet linkedPlanet) {
        ConnectedPlanets.Add(linkedPlanet);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlanetType = (Constants.AlienTypes) Random.Range(0f, Constants.AlienTypesLength - 1.0f);
        PlanetName = (Constants.PlanetNames) Random.Range(0f, Constants.PlanetNamesLength - 1.0f);
    }

    private void OnMouseDown() {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
