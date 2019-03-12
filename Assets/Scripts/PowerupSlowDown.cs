using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSlowDown : MonoBehaviour
{
    private float speed = 2;
    private GamePlay gamePlay;
    public AudioClip clip1;

    [SerializeField]
    private GameObject BubblePop;

    void Start()
    {
        gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
    }
    
    // Update is called once per frame
    void Update()
    {
        speed = gamePlay.speed;
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PaintTrail")
        {
            //add sound fx here (bubble)
            if (PlayerPrefs.GetInt("SFXToggle") == 1)
            {
                AudioSource.PlayClipAtPoint(clip1, new Vector3(5, 1, 2));
            }
            gamePlay.SlowDown();

            Instantiate(BubblePop, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
