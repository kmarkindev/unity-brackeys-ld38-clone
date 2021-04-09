using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public float spawnDistance = 50.0f;
    public float spawnDelay = 2.0f;

    GameManager gameManager;
    private Coroutine spawnCorotine;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnGameStart.AddListener(StartMeteorSpawn);
        gameManager.OnGameOver.AddListener(StopMeteorSpawn);
        gameManager.OnStartMenu.AddListener(StopMeteorSpawn);
    }

    private void StartMeteorSpawn()
    {
        StopMeteorSpawn();
        spawnCorotine = StartCoroutine(SpawnMeteors());
    }

    private void StopMeteorSpawn()
    {
        if (spawnCorotine != null)
            StopCoroutine(spawnCorotine);
    }

    private IEnumerator SpawnMeteors()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnMeteor();
        }
    }

    public void SpawnMeteor()
    {
        var planetPosition = gameManager.Planet.transform.position;
        var randomDir = Random.onUnitSphere;

        var spawnPosition = planetPosition + (randomDir * spawnDistance);

        Instantiate(meteor, spawnPosition, Quaternion.identity);
    }

}
