using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Button maleButton, femaleButton;
    public Transform customizePoint;

    private bool male = true;
    private bool female = false;

    public GameObject activeMaleCharaterModles;
    public GameObject activeFemaleCharaterModles;

    // Use this for initialization
    void Start()
    {
        maleButton.onClick.AddListener(MaleGender);
        femaleButton.onClick.AddListener(FemaleGender);
    }

    // Update is called once per frame
    void Update()
    {
        if (male == true)
        {
            Instantiate(activeMaleCharaterModles, customizePoint);
            Destroy(activeFemaleCharaterModles);
        }

        if (female == true)
        {
            Instantiate(activeFemaleCharaterModles, customizePoint);
            Destroy(activeMaleCharaterModles);
        }
    }

    void MaleGender()
    {
        male = true;
        female = false;
    }

    void FemaleGender()
    {
        male = false;
        female = true;
    }
}
