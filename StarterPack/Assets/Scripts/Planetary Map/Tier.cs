using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier : MonoBehaviour
{
    [SerializeField] public List<GameObject> Planets;
    [SerializeField] public float Difficulty;

    public void AddPlanet() {
        GameObject newPlanet = new GameObject("Planet" + Planets.Count);
        SpriteRenderer planetSprite = newPlanet.AddComponent<SpriteRenderer>();
        planetSprite.sprite = Resources.Load("Temp Planet") as Sprite;
        newPlanet.AddComponent<Planet>();
        Planets.Add(newPlanet);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
