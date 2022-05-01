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
            //SceneManager.LoadScene("Demo Starmap");
        }
    }
}
