using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuiteApplication : MonoBehaviour
{
    private Button quit;
    // Use this for initialization
    void Start()
    {
        quit = GetComponent<Button>();
        quit.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
