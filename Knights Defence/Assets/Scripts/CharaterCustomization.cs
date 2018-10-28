using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaterCustomization : MonoBehaviour
{
    public Button maleButton, femaleButton, finalizeButton;
    public Transform customizePoint;
    public Transform spawnPoint;

    private bool male = true;
    private bool female = false;
    private bool finalize = false;

    public GameObject activeMaleCharaterModles;
    private GameObject activeMaleCharaterModlesObject;
    public GameObject activeFemaleCharaterModles;
    private GameObject activeFemaleCharaterModlesObject;

    // Use this for initialization
    void Start()
    {
        finalize = false;

        maleButton.onClick.AddListener(MaleGender);
        femaleButton.onClick.AddListener(FemaleGender);
        finalizeButton.onClick.AddListener(MoveAvtiveCharaterModle);

        MaleGender();
        MoveAvtiveCharaterModle();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    void MaleGender()
    {
        male = true;
        female = false;

        if (male == true)
        {
            Instantiate<GameObject>(activeMaleCharaterModles, customizePoint.position, customizePoint.rotation, customizePoint);
            activeFemaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Female");

            foreach (Transform obj in customizePoint)
            {
                Destroy(activeFemaleCharaterModlesObject);
            }
        }
    }

    void FemaleGender()
    {
        male = false;
        female = true;

        if (female == true)
        {
            Instantiate<GameObject>(activeFemaleCharaterModles, customizePoint.position, customizePoint.rotation, customizePoint);
            activeMaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Male");

            foreach (Transform obj in customizePoint)
            {
                Destroy(activeMaleCharaterModlesObject);
            }
        }
    }

    void MoveAvtiveCharaterModle()
    {
        finalize = true;

        if (finalize == true)
        {
            if (male == true)
            {
                activeMaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Male");
                activeMaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
                activeMaleCharaterModlesObject.transform.rotation = spawnPoint.transform.rotation;
            }

            if (female == true)
            {
                activeFemaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Female");
                activeFemaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
                activeFemaleCharaterModlesObject.transform.rotation = spawnPoint.transform.rotation;
            }
            //activeMaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
            //activeFemaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
        }
        else if (finalize == false)
        {
            //activeMaleCharaterModlesObject.transform.position = customizePoint.transform.position;
            //activeFemaleCharaterModlesObject.transform.position = customizePoint.transform.position;
        }
    }
}
