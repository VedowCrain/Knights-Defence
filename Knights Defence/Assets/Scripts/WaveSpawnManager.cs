using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class WaveSpawnManager : MonoBehaviour
{
    public List<GameObject> Creature = new List<GameObject>();
    //public GameObject Prefab1;
    //public GameObject Prefab2;
    //public GameObject Prefab3;

    public int numberOfEnemies;
    public int numberOfWaves;
    public float timer = 0;
    private float currenttime;

    public Transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        currenttime = timer;
        numberOfEnemies = 1;

        //Creature.Add(Prefab1);
        //Creature.Add(Prefab2);
        //Creature.Add(Prefab3);
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            StartCoroutine(SpawnWave());
            timer = currenttime;
        }
    }

    int waveCount = 0;

    IEnumerator SpawnWave()
    {
        int enemyCount = 0;

        do
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if (Vector3.Distance(randomPoint.position, FindObjectOfType<player>().transform.position) > 2)
            {
                int prefabIndex = Random.Range(0, Creature.Count);
                Instantiate(Creature[prefabIndex], randomPoint.position, Quaternion.identity);
                enemyCount++;
                yield return new WaitForSecondsRealtime(0.5f);
            }
        } while (enemyCount < numberOfEnemies);

        yield return new WaitForSecondsRealtime(5);

        if (waveCount < numberOfWaves)
        {
            waveCount++;
            StartCoroutine(SpawnWave());
        }
    }

}