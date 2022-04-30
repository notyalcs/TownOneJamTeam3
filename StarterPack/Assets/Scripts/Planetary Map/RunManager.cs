using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RunManager : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerTrain;
    [SerializeField] private List<GameObject> _TierList;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        /*for (int i = 0; i < Constants.Levels; ++i) {
            GameObject Tier = new GameObject("Tier" + i);
            Tier.AddComponent<Tier>();
            Tier ModifyTier = Tier.GetComponent<Tier>();
            if (ModifyTier != null) {
                ModifyTier.Difficulty = i + 1;
            }
            _TierList.Add(Tier);
        }
        for (int i = 0; i < Constants.Levels; ++i) {
            Tier CurrentTier = _TierList[i].GetComponent<Tier>();
            if (CurrentTier == null) return;

            if (i == 0) {
                for (int j = 0; j < Constants.StartNodes; ++j) {
                    CurrentTier.AddPlanet();
                }
            } else if (i == Constants.Levels - 1) {
                CurrentTier.AddPlanet();
            } else if (i < Constants.Levels / 2) {
                Tier PreviousTier = _TierList[i - 1].GetComponent<Tier>();
                float minPlanets = PreviousTier.Planets.Count / 2.0f;
                if (minPlanets == 0) minPlanets = 1;
                createTier((float)Math.Ceiling(minPlanets), PreviousTier.Planets.Count * 2.0f, CurrentTier);
            } else {
                Tier PreviousTier = _TierList[i - 1].GetComponent<Tier>();
                float minPlanets = PreviousTier.Planets.Count / 2.0f;
                if (minPlanets == 0) minPlanets = 1;
                createTier((float)Math.Ceiling(minPlanets), PreviousTier.Planets.Count, CurrentTier);
            }
        }*/
    }

    void createTier(float maxPlanets, float minPlanets, Tier CurrentTier) {
        int NumNewPlanets = (int)Random.Range(minPlanets, maxPlanets);
        for (int j = 0; j < NumNewPlanets; ++j) {
            CurrentTier.AddPlanet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
