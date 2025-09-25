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

    [SerializeField] public bool grabbed;

    [SerializeField] TMP_Text speedText;





    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.left*ballSpeed);

        StartCoroutine(BallServe());
        maxSpeed = ballSpeed * 3;
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = ballSpeed * GameManager.globalSpeedMod;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, curSpeed);

        speedText.text = curSpeed.ToString("#.0");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SwapDirection();
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            Destroy(collision.gameObject);
            
            return;

        }
        else if (collision.gameObject.CompareTag("City"))
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




        yield return new WaitForSeconds(1f);

        rb.velocity = new Vector2(-1, 1) * curSpeed;
        
        print(curSpeed);
        //Math.Sign(playerXPos);

        rb.simulated = true;
    }

}
