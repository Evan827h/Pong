
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float speed = 5f;
    private Vector2 move = new Vector2(0, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        move.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        
    }

    public void setSpeed(float spd)
    {
        speed = spd;
    }
}
