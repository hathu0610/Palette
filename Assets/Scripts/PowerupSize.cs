using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSize : MonoBehaviour
{
    private float speed = 2;
    private GamePlay gamePlay;

    [SerializeField]
    private bool makeLarge;

    public AudioClip clip2;


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
            //add sound fx here (cloud)
            if (PlayerPrefs.GetInt("SFXToggle") == 1)
            {
                AudioSource.PlayClipAtPoint(clip2, new Vector3(5, 1, 2));
            }

           

            if (makeLarge)
            {
                gamePlay.paintTrailSize = 1;
            }
            else
            {
                gamePlay.paintTrailSize = 0;
            }
            Destroy(this.gameObject);
        }
    }
}
