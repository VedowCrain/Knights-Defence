using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public Transform origin;
    private Transform targetObject;
    private GameObject targetPrefab;

    [Space]
    public GameObject woodWall_obj;
    public GameObject stoneWall_obj;

    [Space]
    public Transform woodWall;
    public Transform stoneWall;
    private bool buildMode;

    [Space]
    public KeyCode buildToggleKey;
    public KeyCode Rotate = KeyCode.Q;
    public KeyCode mat_1 = KeyCode.Alpha1;
    public KeyCode mat_2 = KeyCode.Alpha2;

    public LayerMask mask;

    private void Start()
    {
        buildMode = false;
        targetObject = woodWall;
        targetPrefab = woodWall_obj;
    }

    private void Update()
    {
        ToggleBuildMode();
        BuidObject();
    }

    private void ToggleBuildMode()
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
    }

    void BuidObject()
    {
        if (buildMode)
        {
            Ray ray = new Ray(origin.position, origin.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Vector3 snap = new Vector3(
                        Mathf.Round(hit.point.x),
                        10,
                        Mathf.Round(hit.point.z)
                    );

                Ray downRay = new Ray(snap, Vector3.down);
                //Ray downRayOffset = new Ray(snap, new Vector3(0.5f,-1,0));
                RaycastHit downHit;

                if (Physics.Raycast(downRay, out downHit, 100, mask))
                {
                    Debug.DrawRay(downRay.origin, downRay.direction * 10, Color.red);
                    print(downHit.transform.name);
                    snap.y = Mathf.Round(downHit.point.y);
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