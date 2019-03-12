using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    public static backgroundScroller BackgroundScroller;
    private bool madeNew = false;

    private SpawnManager spawnmanager;

    [SerializeField]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundScroller = this;
        spawnmanager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.Find("SpawnManager").GetComponent<GamePlay>().speed;
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -25 && madeNew == false)
        {
            spawnmanager.makeScroller();
            madeNew = true;
        }

        if (transform.position.y < -55)
        {
            Destroy(this.gameObject);
        }
    }
}