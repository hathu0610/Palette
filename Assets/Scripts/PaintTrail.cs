using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTrail : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    private GamePlay gamePlay;
    // Start is called before the first frame update
    void Start()
    {
        gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = gamePlay.speed;
        // Debug.Log("Found Backgroung tag, speed: "+speed);
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -6) 
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.tag);
        if (other.name == "PauseButton")
        {
            gamePlay.Pause();
            Destroy(this.gameObject);
        }
        if (other.tag == "Obstacle")
        {
            Debug.Log("Game over because hit obstacle");
            speed = gamePlay.speed;
            gamePlay.GameOver();
        }
    }
}
