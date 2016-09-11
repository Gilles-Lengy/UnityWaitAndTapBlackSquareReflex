﻿using UnityEngine;
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


    /* Timer */ // http://mafabrique2jeux.fr/blog-fabriquer-jeu-video/20-tutoriels-fr-unity3d/55-timer-unity3d
    public Text textTimer;
    public float startTime;
    public float elapsedTime;

    /*** pour le formatage ****/
   /* private float minutes;
    private float seconds;
    private float centiems;
    */

    private bool timerOn;





    private GameObject sprite2Hit;

    void Start()
    {
        timerOn = false;
        strScore = "Score : ";
        hitCount = 0;
        setHitText();

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

        if (timerOn)
        {
            //le temps écoulé = temps actuel - start time
            elapsedTime = Time.time - startTime;

            //formatage
            /*
            minutes = elapsedTime / 60;
            seconds = elapsedTime % 60;
            centiems = (elapsedTime * 100) % 1000;
            */


            textTimer.text = elapsedTime.ToString();
        }
        else {
            textTimer.text = "Wait...";
        }

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
            timerOn = true;
            startTime = Time.time; // on note le startTime
            yield return new WaitForSeconds(destroyWait);
            Destroy(sprite2Hit);
            timerOn = false;
            yield return new WaitForSeconds(spawnWait);
        }
    }


    void setHitText()
    {
        textHitCount.text = strScore + hitCount.ToString();
    }
}
