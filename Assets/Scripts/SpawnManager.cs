using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject scrollBackground;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject powerupSpeed;

    [SerializeField]
    private GameObject[] powerupSize;

    [SerializeField]
    private GameObject[] powerupColor;

    private int type;
    private float ObDelay;
    private float PowerDelay;
    private bool start;
    private GamePlay gamePlay;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlay.speed>=1f && !start)
        {
            StartCoroutine("SpawnObstacles");
            start = true;
        }

        else if (gamePlay.speed<1f)
        {
            StopCoroutine("SpawnObstacles");
            start = false;
        }
    }

    public void makeScroller()
    {
        Instantiate(scrollBackground, new Vector3(0, 70, 0), Quaternion.identity);
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            type = Random.Range(0, 6);
            ObDelay = Random.Range(2, 4)*(3/gamePlay.speed);
            PowerDelay = Random.Range(0.7f, 2) * (3 / gamePlay.speed);
            if (type < 3)
            {
                Instantiate(obstacle, new Vector3(Random.Range(-2.65f, 2.65f), 8, 0), Quaternion.identity);
                yield return new WaitForSeconds(ObDelay);
            }
            else if (type == 3)
            {
                if(gamePlay.paintTrailSize == 0)
                {
                    Instantiate(powerupSize[1], new Vector3(Random.Range(-2.45f, 2.45f), 8, 0), Quaternion.identity);
                    yield return new WaitForSeconds(PowerDelay);
                }
                else
                {
                    Instantiate(powerupSize[0], new Vector3(Random.Range(-2.45f, 2.45f), 8, 0), Quaternion.identity);
                    yield return new WaitForSeconds(PowerDelay);
                }
            }
            else if (type == 4)
            {   
                if(gamePlay.paintTrailType == 0) {
                    Instantiate(powerupColor[Random.Range(1, 3)], new Vector3(Random.Range(-2.8f, 2.8f), 8, 0), Quaternion.identity);
                    yield return new WaitForSeconds(PowerDelay);
                }
                else if(gamePlay.paintTrailType == 1)
                {
                    Instantiate(powerupColor[2], new Vector3(Random.Range(-2.8f, 2.8f), 8, 0), Quaternion.identity);
                    yield return new WaitForSeconds(PowerDelay);
                }
                else
                {
                    Instantiate(powerupColor[Random.Range(0, 2)], new Vector3(Random.Range(-2.8f, 2.8f), 8, 0), Quaternion.identity);
                    yield return new WaitForSeconds(PowerDelay);
                }
            }
            else
            {
                int slow_down = Random.Range(0, 2);
                if (slow_down != 1)
                {
                Instantiate(powerupSpeed, new Vector3(Random.Range(-2.75f, 2.75f), 8, 0), Quaternion.identity);
                }
                yield return new WaitForSeconds(PowerDelay);
            }
        }
    }
}
