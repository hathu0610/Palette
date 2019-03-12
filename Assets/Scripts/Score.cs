using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;

    private float pointIncreasePerSecond;
    private Text text;
    private GamePlay gamePlay;
    private bool start;
    private float time;
    private float speed;
    Text plusScoreText;

    void Start()
    {
        score = 0f;
        text = GameObject.Find("ScoreText").GetComponent<Text>();
        gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
        plusScoreText = GameObject.Find("PlusScoreText").GetComponent<Text>();
        start = false;
        pointIncreasePerSecond = 0.015f;
    }

    void Update()
    {
        if (gamePlay.speed > 0.1f && !start)
        {
            StartCoroutine(Scoring());
            start = true;
        }

        if (gamePlay.speed == 0)
        {
            StopCoroutine(Scoring());
            start = false;
        }
    }

    public void plusScore(){
        plusScoreText.text = "+2";
        score += 2;
        StartCoroutine("plusScoreTextDisappear");
    }

    IEnumerator plusScoreTextDisappear()
    {
        speed = gamePlay.speed;
        yield return new WaitForSeconds(4.0f/Mathf.Sqrt(speed));
        plusScoreText.text = "";
    }

    IEnumerator Scoring()
    {
        while (true)
        {
            speed = gamePlay.speed;
            score += 3f * pointIncreasePerSecond * speed;
            // Debug.Log("speed: " + speed + ", score: " + score);
            text.text = "" + Mathf.RoundToInt(score);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
