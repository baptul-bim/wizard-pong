using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] public float ballSpeed;
    [SerializeField] public float bounceSpeedMod;
    [SerializeField] private float maxSpeed;



    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.left*ballSpeed);
        rb.velocity = Vector2.left * ballSpeed;

        maxSpeed = ballSpeed * 3;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            if (ballSpeed < maxSpeed)
            {
                ballSpeed = ballSpeed * bounceSpeedMod;
                if (ballSpeed > maxSpeed) { ballSpeed = maxSpeed; }
            }
            

            Vector2 wallCenter = collision.transform.position;
            Vector2 colPoint = collision.contacts[0].point;

            Vector2 newDirection = new Vector2(-1, -0f).normalized; // Always move left with varying vertical angle
            rb.velocity = newDirection * ballSpeed;

        }
        
        //rb.velocity = rb.velocity * bounceSpeedMod;

        
    }
}
