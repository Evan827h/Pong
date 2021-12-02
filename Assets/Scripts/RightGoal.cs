using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoal : MonoBehaviour
{
    public GameObject ball;
    private static int LeftScore { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        LeftScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
        {
            Debug.Log("Score!");
            Destroy(GameObject.Find("Ball"));
            LeftScore++;
            Debug.Log("Left Score: " + LeftScore);
            if (LeftScore == 7)
            {
                Debug.Log("Left wins!");
            }

        }
    }
}
