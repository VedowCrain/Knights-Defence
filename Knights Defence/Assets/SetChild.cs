using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChild : MonoBehaviour
{
    private GameObject activePlayer;

    // Use this for initialization
    void Start()
    {
        if (activePlayer == null)
        {
            activePlayer = GameObject.FindGameObjectWithTag("Male");
        }

        if (activePlayer == null)
        {
            activePlayer = GameObject.FindGameObjectWithTag("Female");
        }

        activePlayer.transform.position = this.transform.position;
        activePlayer.transform.rotation = this.transform.rotation;
        activePlayer.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
