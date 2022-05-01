using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMoneyUpdater : MonoBehaviour
{

    Comp_PlayerController player;

    UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Comp_PlayerController>();
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "$" + player.CurrentMoney.ToString();
    }
}
