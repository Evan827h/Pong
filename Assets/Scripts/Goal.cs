
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject Ball;
    Score scoreScript;
    private int score = 0;
    public int Score { get => score; }

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.Find("Canvas").GetComponent<Score>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
        {
            Destroy(GameObject.Find("Ball"));
            score++;
            scoreScript.updateLeftStart();
            Instantiate(Ball);
            
        }
        else if (collision.transform.name == "Ball(Clone)")
        {
            Destroy(GameObject.Find("Ball(Clone)"));
            score++;
            scoreScript.updateLeftStart();
            Instantiate(Ball);

        }
    }
}
