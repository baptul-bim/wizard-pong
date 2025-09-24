using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] AbilityManager abilityManager;

    [SerializeField] private GameObject ball;
    [SerializeField] float moveSpeed;
    [SerializeField] private float reactionDelay;
    private float ballPos;
    Rigidbody2D rb;

    private Transform currentTransform;


    // Start is called before the first frame update
    void Start()
    {
        abilityManager = GetComponentInChildren<AbilityManager>();


        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindWithTag("Projectile");

        StartCoroutine(ReactionDelay());

        ballPos = ball.transform.position.y - transform.position.y;
    }

    private void Update()
    {
        if (ball.transform.position.x >= 7)  
        {
            StartCoroutine(abilityManager.WallAbility());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTransform = this.transform;
        if (currentTransform.position.x > ball.transform.position.x)
        {
            if (currentTransform.position.y < ball.transform.position.y)
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.up * moveSpeed, reactionDelay * Time.deltaTime);
            }
            else if (currentTransform.position.y > ball.transform.position.y)
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.down * moveSpeed, reactionDelay * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero * moveSpeed, reactionDelay * Time.deltaTime);
            }

        }

    }
    IEnumerator ReactionDelay() // OLD
    {
       // float currentBallPos = ball.transform.position.y - transform.position.y;

        yield return new WaitForSeconds(reactionDelay);
      //  this.transform.position.y = MoveTowards(transform.position.y, currentBallPos);
        

        StartCoroutine(ReactionDelay());
    }
}
