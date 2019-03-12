using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static GamePlay game;
    public Animator transitionAnimGameOver;

    [SerializeField]
    private GameObject[] _paintTrailPrefab;

    [SerializeField]
    private GameObject[] _paintTrailSmall;

    private Vector3 _oldPaintTrailPos;

    private Vector3 _paintTrailPos;

    private Vector3 fingerPos;

    public bool start;

    public int paintTrailType = 0;
    public int paintTrailSize = 1;

    [SerializeField]

    private int trailLength;

    public float speed = 0f;

    private float lastTouch = -1.0f;

    private float oldSpeed = 2.0f;
    private float lastTouchEnded = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
        game = this;
        _oldPaintTrailPos = new Vector3(0, 0, 0);
        _paintTrailPos = new Vector3(0, 0, -1);
        // Debug.Log("start: " + start);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("start: " + start);
        if (start)
        {
            float time = Time.time - lastTouchEnded;
            if (lastTouchEnded > 0.0f && time > .8f)
            {
                // Debug.Log("Time: " + time);
                GameOver();
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        lastTouchEnded = -1.0f;
                        if (lastTouch > 0)
                        {
                            // Debug.Log("Time before last touch: " + (Time.time - lastTouch));
                            if (Time.time - lastTouch < .8f)
                            {
                                Pause();
                                // Debug.Log("Pause because double tap");
                            } else
                            {
                                lastTouch = Time.time;
                            }
                        }
                        else
                        {
                            Debug.Log("First begin touch");
                            speed = oldSpeed;
                            oldSpeed = speed;
                            fingerPos = getTouch(touch);
                            _oldPaintTrailPos = _paintTrailPos;
                            _paintTrailPos = fingerPos;
                            StartTrail();
                            StartCoroutine("SpeedUp");
                            lastTouch = Time.time;
                        }
                        break;
                    case TouchPhase.Moved:
                        fingerPos = getTouch(touch);
                        _oldPaintTrailPos = _paintTrailPos;
                        _paintTrailPos = fingerPos;
                        break;
                    case TouchPhase.Ended:
                        StartCoroutine("Wait");
                        lastTouchEnded = Time.time;
                        // Debug.Log("Last touch ended: "+lastTouchEnded);
                        break;
                }
            }
        }
    }

    Vector3 getTouch(Touch touch)
    {
        Vector3 fingerPos = touch.position;
        fingerPos.z = -10;
        fingerPos = Camera.main.ScreenToWorldPoint(fingerPos);
        fingerPos.x = -fingerPos.x;
        if (fingerPos.x > 3.4)
        {
            fingerPos.x = 3.4f;
        }
        if (fingerPos.x < -3.4)
        {
            fingerPos.x = -3.4f;
        }
        fingerPos.y = -fingerPos.y + 1.7f;
        fingerPos.z = 0;
        return fingerPos;
    }

    IEnumerator SpawnPaintTrail()
    {
        while (true)
        {
            if(paintTrailSize == 1)
            {
                Instantiate(_paintTrailPrefab[paintTrailType], _paintTrailPos, Quaternion.identity);
                Score.score += .015f;
                yield return new WaitForSeconds(.02f);
            }
            else
            {
                Instantiate(_paintTrailSmall[paintTrailType], _paintTrailPos, Quaternion.identity);
                Score.score += .015f;
                yield return new WaitForSeconds(.02f);
            }
            
        }
    }

    public void StartTrail()
    {
        GameObject TouchToStartText = GameObject.Find("TouchToStartText");
        TouchToStartText.GetComponent<UnityEngine.UI.Text>().text = "";
        StartCoroutine("SpawnPaintTrail");
    }

    public void StopTrail()
    {
        StopCoroutine("SpawnPaintTrail");
    }

    public void Pause()
    {
        start = false;
        oldSpeed = speed;
        speed = 0f;
        lastTouch = -1.0f;
        lastTouchEnded = -1.0f;
        StopTrail();
        // SpriteRenderer pauseSprite = GameObject.Find("PauseButton").GetComponent<SpriteRenderer>();
        SpriteRenderer resumeSprite = GameObject.Find("ResumeButton").GetComponent<SpriteRenderer>();
        // pauseSprite.sortingOrder = 0;
        resumeSprite.sortingOrder = 8;
        StopCoroutine("SpeedUp");
    }

    public void Resume()
    {
        // SpriteRenderer pauseSprite = GameObject.Find("PauseButton").GetComponent<SpriteRenderer>();
        SpriteRenderer resumeSprite = GameObject.Find("ResumeButton").GetComponent<SpriteRenderer>();
        // pauseSprite.sortingOrder = 4;
        resumeSprite.sortingOrder = 0;
        StartCoroutine("GameResume");
    }

    IEnumerator GameResume()
    {
        yield return new WaitForSeconds(.5f);
        start = true;
    }

    IEnumerator Slow()
    {
        float temp = speed;
        speed = speed/2;
        yield return new WaitForSeconds(5);
        speed = temp;
    }

    public void SlowDown()
    {
        StartCoroutine("Slow");
    }

    public void GameOver()
    {
        // Add Transition
        oldSpeed = speed;
        speed = 0f;
        StopTrail();
        // SpriteRenderer pauseSprite = GameObject.Find("PauseButton").GetComponent<SpriteRenderer>();
        // pauseSprite.sortingOrder = 0;
        StopCoroutine("SpeedUp");
        StartCoroutine("WaitThenGameOver");
    }

    IEnumerator WaitThenGameOver()
    {
        transitionAnimGameOver.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator SpeedUp()
    {
        while (true) {
            speed += .15f;
            yield return new WaitForSeconds(.5f);
        }
    }
}
