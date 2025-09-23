using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] public float ballSpeed;
    [SerializeField] public float bounceSpeedMod;
    [SerializeField] public float curSpeed;
    [SerializeField] private float maxSpeed;

    [SerializeField] public bool grabbed;





    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.left*ballSpeed);
        rb.velocity = new Vector2(-1, 1) * ballSpeed;

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
            SwapDirection();
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            /*if (ballSpeed < maxSpeed)
            {
                ballSpeed = ballSpeed * GameManager.globalSpeedMod;
                curSpeed = ballSpeed;
                if (ballSpeed > maxSpeed) { ballSpeed = maxSpeed; curSpeed = maxSpeed; }
            }*/


            /* Vector2 wallCenter = collision.transform.position;
             Vector2 colPoint = collision.contacts[0].point;*/

            //Vector2 newDirection = new Vector2(-1, -0f).normalized; 
            //rb.velocity = newDirection * ballSpeed;
            
            return;

        }
        
        //rb.velocity = rb.velocity * bounceSpeedMod;

        
    }


    public void SwapDirection()
    {
        rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
    }

}
