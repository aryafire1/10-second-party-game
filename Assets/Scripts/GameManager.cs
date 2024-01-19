using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject gem;
    public GameObject player;
    public GameObject winScreen;
    public GameObject lossScreen;

    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text titleText;
    public TMP_Text countdownText;


    public float titleTime = 2f;
    public float timeLeft = 10f;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        //this is bad code i know but let me have this
        //gem spawning
        InvokeRepeating("GemSpawn", 2f, 3f);
        InvokeRepeating("GemSpawn", 3f, 4f);

    }

    // Update is called once per frame
    void Update()
    {
        //countdown
        titleTime -= Time.deltaTime;
        countdownText.text = (titleTime).ToString("0");

        Gameplay();
        GoodEnd();
        BadEnd();
       
    }

    void GemSpawn()
    {
        Instantiate(gem, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0), Quaternion.identity);
    }

    public void EarnScore()
    {
        score = score + 1;
        scoreText.text = "Score: " + score;
    }

    void Gameplay()
    {
        if(titleTime < 0)
        {
            Destroy(titleText);
            Destroy(countdownText);

            //10 second timer
            timeLeft -= Time.deltaTime;
            timeText.text = (timeLeft).ToString("0");
        }
    }

    void GoodEnd()
    {
        if(score >= 5)
        {
            Destroy(timeText);
            Destroy(scoreText);
            Destroy(player);
            Destroy(gem);
            CancelInvoke();
            winScreen.SetActive(true);
        }
    }

    void BadEnd()
    {
        if (timeLeft <= 0 && score <= 4)
        {
            Destroy(timeText);
            Destroy(scoreText);
            Destroy(player);
            Destroy(gem);
            CancelInvoke();
            lossScreen.SetActive(true);
        }
    }
}
