using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
 
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

        }
    }
}
