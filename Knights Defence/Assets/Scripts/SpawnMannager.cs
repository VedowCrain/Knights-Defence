using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMannager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] ememies;
    private float spawnDelay = 0;
    public float originalspawndelay = 60;
    public int numberOfBosses = 1;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnDelay -= Time.deltaTime;

        if (spawnDelay <= 0)
        {
            for (int i = 0; i < numberOfBosses; i++)
            {
                SpawnEnemy();
            }
        }
      
    }

    void SpawnEnemy ()
    {
        int index = Random.Range(0, spawnpoints.Length);
        GameObject obj = spawnpoints[index];
        Instantiate(ememies[Random.Range(0, ememies.Length)], obj.transform.position, obj.transform.rotation);
        spawnDelay = originalspawndelay;
    }
}
