using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] public float ballSpeed;
    [SerializeField] public float bounceSpeedMod;
    [SerializeField] public float curSpeed;
    [SerializeField] private float maxSpeed;

    public Vector2 savedVelocity;

    private float serveSpeed;

    private bool firstBounce = true;

    [SerializeField] public bool grabbed;

    [SerializeField] TMP_Text speedText;





    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.left*ballSpeed);

        StartCoroutine(BallServe());
        maxSpeed = ballSpeed * 3;

        StartCoroutine(ServeSpeedIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = ballSpeed * GameManager.globalSpeedMod;
        //rb.velocity = savedVelocity;
        

        

        speedText.text = curSpeed.ToString("#.0");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var normal = collision.contacts[0].normal;

        Vector2 bounce = Vector2.Reflect(savedVelocity, normal);


        Debug.DrawLine(collision.contacts[0].point, normal + collision.contacts[0].point, Color.red, 2f);
        Debug.DrawLine(collision.contacts[0].point, collision.contacts[0].point - rb.velocity, Color.green, 2f);
        Debug.DrawLine(collision.contacts[0].point, collision.contacts[0].point + bounce, Color.blue, 2f);

        rb.velocity = bounce;

        savedVelocity = rb.velocity;




        if (firstBounce)
        {
            print("firstbounce");
            //float firstBounceAngle = UnityEngine.Random.Range(-90, 90);
            float firstBounceAngle = UnityEngine.Random.Range(0, 1);


            
            if (firstBounceAngle == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Quaternion.Euler(0, 110, 0).y); //APPROXIMATELY 10 DEGREES. I EYEBALLED IT WITH AN ACTUAL RULER.
                //rb.angularVelocity = -10;
            }
            else if (firstBounceAngle == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, Quaternion.Euler(0, -110, 0).y); //APPROXIMATELY -10 DEGREES. I EYEBALLED IT WITH AN ACTUAL RULER.
                //rb.angularVelocity = 10;
            }

            savedVelocity = rb.velocity;
            firstBounce = false;

        }

      /*  if (collision.gameObject.CompareTag("Wall"))
        {

            //rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            //Destroy(collision.gameObject);
            
            return;

        }*/
        if (collision.gameObject.CompareTag("City"))
        {
            collision.gameObject.GetComponent<CityManager>().DamageCity(rb.velocity.magnitude*2);
        }


        
        
        //rb.velocity = rb.velocity * bounceSpeedMod;

        
    }


    public void SwapDirection()
    {
        rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
    }

    public IEnumerator BallServe(/*float playerXPos*/)
    {
        rb.simulated = false;




        yield return new WaitForSeconds(2);

        rb.velocity = new Vector2(-1 + serveSpeed, 0) * curSpeed;
        savedVelocity = rb.velocity;
        print(curSpeed);
        //Math.Sign(playerXPos);

        rb.simulated = true;
    }

    private IEnumerator ServeSpeedIncrease()
    {

        yield return new WaitForSeconds(10);
        serveSpeed += 0.5f;
        StartCoroutine(ServeSpeedIncrease());

    }

}
