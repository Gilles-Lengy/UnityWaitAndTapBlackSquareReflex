using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject srite2Duplicate;
    public Vector2 spawnValues;
    public int hitCount;
    public float startWait;
    public float spawnWait;
    public float destroyWait;

    


    private GameObject sprite2Hit;

    void Start()
    {
        hitCount = 0;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        { 
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y));
                Quaternion spawnRotation = Quaternion.identity;
            sprite2Hit = Instantiate(srite2Duplicate, spawnPosition, spawnRotation) as GameObject;
            yield return new WaitForSeconds(destroyWait);
            Destroy(sprite2Hit);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
