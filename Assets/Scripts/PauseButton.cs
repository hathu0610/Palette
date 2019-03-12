using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private Collider2D _collider;

    void OnMouseDown()
    {
        GamePlay gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
        if (gamePlay.speed > 0.1f)
        {
            gamePlay.Pause();
            Debug.Log("Hitted Pause Button by click");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos = new Vector3(-touchPos.x, -touchPos.y+1, 0);

            if (_collider == Physics2D.OverlapPoint(touchPos))
            {
                Debug.Log("Touch Pause Button"+ touchPos);
                Debug.Log("Hitted Pause Button by Touch");
                GamePlay gamePlay = GameObject.Find("SpawnManager").GetComponent<GamePlay>();
                gamePlay.Pause();
            }
        }
    }
}
