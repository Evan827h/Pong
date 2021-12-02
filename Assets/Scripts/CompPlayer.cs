
using UnityEngine;

public class CompPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float speed = 8f;

    GameObject Ball;
    Ball ballScript;
    Rigidbody2D ballRb;
    Score score;
    public GameObject circle;

    Vector2 move;
    float yPredict;
    int prevLeftScore = 0;
    int prevRightScore = 0;


    void Start()
    {
        Ball = GameObject.Find("Ball");
        ballScript = Ball.GetComponent<Ball>();
        ballRb = Ball.GetComponent<Rigidbody2D>();
        score = GameObject.Find("Canvas").GetComponent<Score>();
    }

    void FixedUpdate()
    {
        if (score.LeftScore > prevLeftScore || score.RightScore > prevRightScore)
        {
            Ball = GameObject.Find("Ball(Clone)");
            ballScript = Ball.GetComponent<Ball>();
            ballRb = Ball.GetComponent<Rigidbody2D>();
        }
        if (ballScript.Force.x > 0)
        {
            yPredict = Plot(ballRb, ballRb.position, ballScript.Force, 10);
            move = new Vector2(7.18f, yPredict);
        }
        else
        {
            move = new Vector2(7.18f, 0f);
        }

        if (rb.position.y >= move.y + 0.1f || rb.position.y < move.y - 0.1f)
        {
            
            Vector2 moveTo = new Vector2(0,0);
            if(rb.position.y < move.y)
            {
                moveTo.y = 0.5f;
            }
            if(rb.position.y > move.y)
            {
                moveTo.y = -0.5f;
            }

            Vector2 movePos = rb.position + moveTo * speed * Time.fixedDeltaTime;
            movePos.x = 7.18f;
            rb.MovePosition(movePos);
        }
        prevLeftScore = score.LeftScore;
        prevRightScore = score.RightScore;

    }

    public float Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {

        float timestep = (Time.fixedDeltaTime / Physics2D.velocityIterations) * 50;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; ++i)
        {
            pos += moveStep;

            
            if(pos.y == 4.98f || pos.y == -4.98f)
            {
                velocity.y = -velocity.y;
                moveStep = velocity * timestep;
            }
            if(pos.x > 7)
            {
                return pos.y;
            }
            //Visuals
            //Vector3 circleSet = new Vector3(pos.x, pos.y, 0);
            //Instantiate(circle, circleSet, new Quaternion(0, 0, 0, 0));
        }

        return 0f;
    }

    public void setSpeed(float spd)
    {
        speed = spd;
    }

}
