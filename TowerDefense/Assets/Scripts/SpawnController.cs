using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public static int enemysAlives = 0;
    public Wave[] waves;
    public Transform spawnPoints;
    public float timeBetweenWaves = 5;
    float countdown = 2;
    int waveIndex = 0;

    // Use this for initialization
    void Start () {
        enemysAlives = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (enemysAlives > 0)
            return;

        if (waveIndex == waves.Length)
        {
            GameManager.instance.WinLevel();
            enabled = false;
        }

        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
	}

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        PlayerStats.Round++;
        enemysAlives = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoints.position, spawnPoints.rotation, spawnPoints);
    }
}
