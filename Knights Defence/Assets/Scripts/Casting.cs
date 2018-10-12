using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CastMode
{
    Fire,
    Sword,
    Orb
}

public class Casting : MonoBehaviour
{
    public Transform origin;
    private GameObject targetPrefab;
    public GameObject woodWall_obj;
    public GameObject stoneWall_obj;
    private Transform targetObject;
    public Transform woodWall;
    public Transform stoneWall;
    public KeyCode buildToggleKey;
    public bool buildMode;
    public KeyCode Rotate = KeyCode.Q;
    public KeyCode mat_1 = KeyCode.Alpha1;
    public KeyCode mat_2 = KeyCode.Alpha2;

    private CastMode castMode = CastMode.Fire;


    private void Start()
    {
        buildMode = false;
        targetObject = woodWall;
        targetPrefab = woodWall_obj;
    }

    private void Update()
    {
        if (Input.GetKeyDown(buildToggleKey))
        {
            buildMode = !buildMode;

            if (!buildMode)
            {
                targetObject.position = new Vector3(0, 0, 0);
                stoneWall.position = new Vector3(0, 0, 0);
                woodWall.position = new Vector3(0, 0, 0);
            }
        }




        if (buildMode)
        {
            Ray ray = new Ray(origin.position, origin.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 snap = new Vector3(
                        Mathf.Floor(hit.point.x) + 0.5f,
                        10,
                        Mathf.Floor(hit.point.z) + 0.5f
                    );

                Ray downRay = new Ray(snap, Vector3.down);
                //Ray downRayOffset = new Ray(snap, new Vector3(0.5f,-1,0));
                RaycastHit downHit;

                if (Physics.Raycast(downRay, out downHit))
                {
                    snap.y = Mathf.Floor(downHit.point.y) + 0.5f;
                    targetObject.position = snap;
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    Instantiate(targetPrefab, snap, targetObject.rotation);
                }

                if (Input.GetKeyDown(Rotate))
                {
                    targetObject.Rotate(0, 90, 0);
                }

                if (Input.GetKeyDown(mat_1))
                {
                    targetObject = woodWall;
                    targetPrefab = woodWall_obj;
                    stoneWall.position = new Vector3(0, 0, 0);
                }

                if (Input.GetKeyDown(mat_2))
                {
                    targetObject = stoneWall;
                    targetPrefab = stoneWall_obj;
                    woodWall.position = new Vector3(0, 0, 0);
                }
            }
            else
            {
                targetObject.position = new Vector3(0, 0, 0);
                stoneWall.position = new Vector3(0, 0, 0);
                woodWall.position = new Vector3(0, 0, 0);
            }

        }

    }
}