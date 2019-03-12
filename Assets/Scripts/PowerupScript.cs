using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupScript : MonoBehaviour
{
    private float speed = 2;
    private GamePlay gamePlay;
    public AudioClip clip;

    void Start()
    {
        gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
    }

    [SerializeField]
    private int colorType;

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
            GameObject.Find("SpawnManager").GetComponent<Score>().plusScore();

            // add sound fx here (droplet)
            if (PlayerPrefs.GetInt("SFXToggle") == 1)
            {
                AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
            }
            if (colorType == 0)
            {
                gamePlay.paintTrailType = 0;

            }
            else if (colorType == 1)
            {
                gamePlay.paintTrailType = 1;
            }
            else
            {
                gamePlay.paintTrailType = 2;
            }
            Destroy(this.gameObject);
        }
    }
}
