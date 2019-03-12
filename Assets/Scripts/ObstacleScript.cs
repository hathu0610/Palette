using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;
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
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if(transform.position.y < -9)
        {
            // Debug.Log("Destroy at y=" + transform.position.y);
            Destroy(this.gameObject);
        }
    }
}
