using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float globalSpeedMod = 1;

    public static bool canUseAbilities = false;

    [SerializeField] GameObject player1;
    
    
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player2Wall;

    [SerializeField] GameObject ball;
    [SerializeField] GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        globalSpeedMod = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (globalSpeedMod > 3)
        {
            globalSpeedMod = 3;
        }

       /* if (ball != null)
        {
            ball = Instantiate(ballPrefab, Vector2.zero, this.transform.rotation);

            ball.GetComponent<BallMove>().BallServe(player2.transform.position.x);

        }*/
    }



    public IEnumerator Serve()
    {


        yield return new WaitForSeconds(globalSpeedMod);
    }
}
