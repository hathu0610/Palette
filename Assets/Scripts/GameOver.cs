using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Text flashingText;
    //flag to determine if you want the blinking to happen
    public static int highscore;

    // Start is called before the first frame update
    void Start()
    {
        flashingText = GameObject.Find("NewHighScoreText").GetComponent<Text>();

        highscore = PlayerPrefs.GetInt("highscore", highscore);

        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "" + Mathf.RoundToInt(Score.score);

        if (Score.score > highscore) {
            highscore = Mathf.RoundToInt(Score.score);
            GameObject.Find("BestText").GetComponent<Text>().text="";
            Debug.Log("Best Text: " + GameObject.Find("BestText").GetComponent<Text>().text);
            StartCoroutine("BlinkText");
        }

        PlayerPrefs.SetInt("highscore", highscore);
        Text highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
        highScoreText.text = "" + highscore;
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        while (true)
        {
            //set the Text's text to blank
            flashingText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            flashingText.text = "New High Score!";
            yield return new WaitForSeconds(.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
