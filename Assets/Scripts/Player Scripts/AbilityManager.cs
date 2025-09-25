using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] GameObject centerObj;


    [Header("Wall Ability")]
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject spawnPosObj;
    [SerializeField] Slider cdSlider;
    [SerializeField] private float wallDuration;
    [SerializeField] private float wallOffset;
    [SerializeField] private float wallCd = 0.5f;
    float wallCDvalue;
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
        if (abilityReady == false && wallCDvalue > 0)
        {
            wallCDvalue -= Time.deltaTime;
            cdSlider.value = wallCDvalue;
        }



    }


    public IEnumerator WallAbility()
    {
<<<<<<< Updated upstream
        if (wallReady)
=======
        if (abilityReady && (Math.Sign(Mathf.Abs(spawnPosObj.transform.position.x) - Mathf.Abs(ball.transform.position.x)) > 0))
>>>>>>> Stashed changes
        {
            wallReady = false;
            GameObject wallInstance;

            wallInstance = Instantiate(wallPrefab, spawnPosObj.transform.position, this.transform.rotation);

            Rigidbody wallRB = wallInstance.GetComponent<Rigidbody>();
            //  shotInstance.GetComponent<Rigidbody>().AddForce(shotInstance.transform.forward * shotSpeed, 1, 1);

            //shotRB.AddForce(gameObject.transform.forward * shotSpeed);

            Destroy(wallInstance, wallDuration);

            wallCDvalue = wallCd;
            //StartCoroutine(CooldownBar());
            yield return new WaitForSeconds(wallCd);
            wallReady = true;
        }
        else if (abilityReady) { print("nuh uh!"); }
        
    }

    private IEnumerator CooldownBar()
    {

        wallCDvalue -= Time.deltaTime;
        cdSlider.value = wallCDvalue;

        if (wallCDvalue <= 0) 
        {
            yield return null;
        }
     //   cdSlider.value = Mathf.MoveTowards(cdSlider.value, 0, wallCd * Time.deltaTime);
        

    }

    public IEnumerator GrabAbility()
    {
        Vector2 ballPos = ball.transform.position;
        if (Vector2.Distance(ballPos, this.transform.position) <= grabRange)
        {
            tempGrabFX.SetActive(true);
<<<<<<< Updated upstream
            wallReady = false;

            GameManager.globalSpeedMod += 0.1f;
            print(GameManager.globalSpeedMod);
=======
            abilityReady = false;
            Vector2 ballPos = ball.transform.position;

            if (Vector2.Distance(ballPos, this.transform.position) <= grabRange)
            {
                
                
>>>>>>> Stashed changes

            ballRb.simulated = false;
            ballScript.SwapDirection();
            yield return new WaitForSeconds(grabDuration);

<<<<<<< Updated upstream
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
=======
                int ballXPos = Math.Sign(ball.GetComponent<Rigidbody2D>().velocity.x);
                int playerXPos = Math.Sign(this.transform.position.x);

                if (playerXPos + ballXPos != 0)
                {
                    ballScript.SwapDirection(); ;
                }
                /*else if (playerXPos + ballXPos == 0)
                {
                    
                }
                else
                {
                    
                }*/
                

                    ballRb.simulated = false;
                
                yield return new WaitForSeconds(grabDuration);

                ballRb.simulated = true;
                ballRb.velocity = new Vector2(ballRb.velocity.x, ballRb.velocity.y) * GameManager.globalSpeedMod;


                tempGrabFX.SetActive(false);
                abilityReady = true;
                
            }
            else
            {
                yield return new WaitForSeconds(grabDuration);

                abilityReady = true;
                tempGrabFX.SetActive(false);
            }
>>>>>>> Stashed changes
        }
        

    }
    
}
