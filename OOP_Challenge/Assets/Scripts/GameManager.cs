using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int enemyCount;
    
    [SerializeField] bool isGameActive;

    [SerializeField] List<GameObject> enemyPrefab;

    [SerializeField] public static int playerHealth { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(spawnEnemy());

        playerHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemy()
    {
        while (isGameActive)
        {

            int minTimeToSpawn = 1;
            int maxTimeToSpawn = 5;

            int randomTimeSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            int enemyIndex = Random.Range(0,3);

            yield return new WaitForSeconds(randomTimeSpawn);
            Instantiate(enemyPrefab[enemyIndex], SpawnRandomEnemyPos(), enemyPrefab[enemyIndex].transform.rotation);
            enemyCount++;

            Debug.Log("enemyCount: " + enemyCount + " prefab name: " + enemyPrefab[enemyIndex].name);

        }
    }

    private Vector3 SpawnRandomEnemyPos()
    {
        float radius = 10f;
        Vector3 randomPos = Random.insideUnitSphere * radius;

        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;


        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);

        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.z = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.z;
        
        return randomPos;
    }
}
