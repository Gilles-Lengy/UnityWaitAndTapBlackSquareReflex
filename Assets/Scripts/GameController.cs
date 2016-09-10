using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject srite2Duplicate;
    public Vector2 spawnValues;
    public int hitCount;
    public float startWait;
    public float spawnWait;
    public float destroyWait;
    public Text textHitCount;
    private string strScore;





    private GameObject sprite2Hit;

    void Start()
    {
        strScore = "Score : ";
        hitCount = 0;
        setHitText();

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

        for (int i = 0; i < Input.touchCount; ++i)
        {

            if (Input.GetTouch(i).phase == TouchPhase.Began) {

                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                if (sprite2Hit.GetComponent<Collider2D>().OverlapPoint(wp))
                {
                    hitCount++;
                    setHitText();
                    Destroy(sprite2Hit);
                }
                }
        }
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


    void setHitText()
    {
        textHitCount.text = strScore + hitCount.ToString();
    }
}
