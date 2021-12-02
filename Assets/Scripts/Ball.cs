
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 Force = new Vector2(3, 15);
    public Vector2 startPos;
    public static float acceleration = 5f;
    private Vector2 velo;
    private int count;
    private float prevYPos = 0;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Canvas").GetComponent<Score>();
        if (score.LeftStart)
        {
            float x = Random.Range(-5f, 0.5f);
            float y = Random.Range(-3.5f, 3.5f);
            startPos = new Vector2(x,y);
            
        }
        else
        {
            float x = Random.Range(0.5f, 5f);
            float y = Random.Range(-3.5f, 3.5f);
            startPos = new Vector2(x, y);
            Force.x = -Force.x;
        }
        if (startPos.y < 0f)
        {
            Force.y = -Force.y;
        }
        rb.MovePosition(startPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Thing to keep the ball from getting stuck in pinch
        if(rb.position.y >= prevYPos - 0.005f && rb.position.y <= prevYPos + 0.005f)
        {
            count++;
        }
        else
        {
            count = 0;
        }
        if(count > 5)
        {
            if(rb.position.y >= 0)
            {
                Force.y = -5;
            }
            else
            {
                Force.y = 5;
            }
            count = 0;
        }

        rb.AddForce(Force);
        prevYPos = rb.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = velo * rb.velocity;

        if(collision.transform.name == "Border")
        {
            if(Force.x > 0)
            {
                Force.x += acceleration;
            }
            else
            {
                Force.x -= acceleration;
            }
            Force.y = -Force.y;
        }
        else
        {
            
            if (Force.x > 0)
            {
                Force.x += acceleration;
            }
            else
            {
                Force.x -= acceleration;
            }
            Force.x = -Force.x;
        }

    }

    public void setAcceleration(float accel)
    {
        acceleration = accel;
    }
}
