using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableElement : MonoBehaviour
{

    Comp_Spawner spawner;
    int thisItemIndex;

    Comp_SpawnerController spawnerController;

    public void Initialize(Comp_Spawner spn, int index, Comp_SpawnerController controller)
    {
        spawnerController = controller;
        spawner = spn;
        thisItemIndex = index;
        UnityEngine.UI.Image img =  transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>();
        SpriteRenderer sr = spn._unitPrefab.GetComponent<SpriteRenderer>();
        img.sprite = sr.sprite;
        img.color = sr.color;
        UnityEngine.UI.Text text = GetComponentInChildren<UnityEngine.UI.Text>();
        text.text = spn.SpawnCost.ToString();
    }

    public void clickevent()
    {
        Debug.Log("Clicked");
        spawnerController.SetSelectedIndex(thisItemIndex);
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
