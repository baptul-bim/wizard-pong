using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] GameObject centerObj;


    [Header("Wall Ability")]
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject spawnPosObj;
    [SerializeField] private float wallDuration;
    [SerializeField] private float wallOffset;
    [SerializeField] private float wallCd = 0.5f;
    [SerializeField] private bool wallReady;

    [Header("Grab Ability")]
    [SerializeField] GameObject ball;
    [SerializeField] Rigidbody2D ballRb;
    [SerializeField] GameObject tempGrabFX;
    [SerializeField] BallMove ballScript;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float grabRange;
    [SerializeField] private float grabDuration;


    // Start is called before the first frame update
    void Start()
    {
        wallReady = true;
        ball = GameObject.FindWithTag("Projectile");
        ballRb = ball.GetComponent<Rigidbody2D>();
        ballScript = ball.GetComponent<BallMove>();

        ballSpeed = 1;

        spawnPosObj = transform.Find("WallSpawn").gameObject;
        print(ball);
    }

    // Update is called once per frame
    void Update()
    {




    }


    public IEnumerator WallAbility()
    {
        if (wallReady)
        {
            wallReady = false;
            GameObject wallInstance;

            wallInstance = Instantiate(wallPrefab, spawnPosObj.transform.position, this.transform.rotation);

            Rigidbody wallRB = wallInstance.GetComponent<Rigidbody>();
            //  shotInstance.GetComponent<Rigidbody>().AddForce(shotInstance.transform.forward * shotSpeed, 1, 1);

            //shotRB.AddForce(gameObject.transform.forward * shotSpeed);

            Destroy(wallInstance, wallDuration);

            yield return new WaitForSeconds(wallCd);
            wallReady = true;
        }
        
    }

    public IEnumerator GrabAbility()
    {
        Vector2 ballPos = ball.transform.position;
        if (Vector2.Distance(ballPos, this.transform.position) <= grabRange)
        {
            tempGrabFX.SetActive(true);
            wallReady = false;

            GameManager.globalSpeedMod += 0.1f;
            print(GameManager.globalSpeedMod);

            ballRb.simulated = false;
            ballScript.SwapDirection();
            yield return new WaitForSeconds(grabDuration);

            ballRb.simulated = true;
            ballRb.velocity = new Vector2(ballRb.velocity.x, ballRb.velocity.y) * GameManager.globalSpeedMod;


            tempGrabFX.SetActive(false);
            wallReady = true;
        }
        else
        {
            tempGrabFX.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            tempGrabFX.SetActive(false);
        }
        

    }
    
}
