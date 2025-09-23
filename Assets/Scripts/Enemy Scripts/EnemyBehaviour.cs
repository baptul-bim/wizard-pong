using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] float moveSpeed;
    [SerializeField] private float reactionDelay;
    private float ballPos;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindWithTag("Projectile");

        StartCoroutine(ReactionDelay());

        ballPos = ball.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {

      //  float currentBallPos = ball.transform.position.y - transform.position.y;
        //ballPos = Mathf.Lerp(ballPos, currentBallPos, Time.deltaTime * reactionDelay);

        ballPos = Mathf.Lerp(ballPos, ball.transform.position.y, Time.deltaTime * reactionDelay);
        float diff = ballPos - transform.position.y;

        if (diff < 5)
        {
            if (transform.position.y > ballPos) { rb.velocity = (new Vector2(0, -moveSpeed)); }
            if (transform.position.y < ballPos) { rb.velocity = (new Vector2(0, moveSpeed)); }
        }

        

        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeed);

        /*  Vector2 targetPosition = new Vector2(0, ball.transform.position.y);

          transform.position = Vector2.MoveTowards(transform.position, targetPosition, reactionDelay * Time.deltaTime);
        */

    }


    IEnumerator ReactionDelay()
    {
       // float currentBallPos = ball.transform.position.y - transform.position.y;

        yield return new WaitForSeconds(reactionDelay);
      //  this.transform.position.y = MoveTowards(transform.position.y, currentBallPos);
        

        StartCoroutine(ReactionDelay());
    }
}
