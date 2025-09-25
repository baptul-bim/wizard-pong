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
    private Vector2 ballPos;
    Rigidbody2D rb;

    private Transform currentTransform;


    // Start is called before the first frame update
    void Start()
    {
        abilityManager = GetComponentInChildren<AbilityManager>();


        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindWithTag("Projectile");

    }

    private void Update()
    {
        ballPos = ball.transform.position;

        if (ball.GetComponent<Rigidbody2D>().velocity.x! > 0)
        {
            if (Vector2.Distance(ballPos, transform.position) <= 1f)
            {
                print("grab??");
                StartCoroutine(abilityManager.GrabAbility());
            }
            if (ballPos.x >= 7)
            {
               StartCoroutine(abilityManager.WallAbility());
            }

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTransform = this.transform;
        if (currentTransform.position.x > ball.transform.position.x)
        {
            

            if (currentTransform.position.y + 0.5f < ball.transform.position.y) //if ball high go up
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.up * moveSpeed, reactionDelay * Time.deltaTime);
            }
            else if (currentTransform.position.y - 0.5f > ball.transform.position.y) //if ball low go down
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.down * moveSpeed, reactionDelay * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero * moveSpeed, reactionDelay * Time.deltaTime);
            }

        }

    }

}
