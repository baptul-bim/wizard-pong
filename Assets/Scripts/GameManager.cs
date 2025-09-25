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

    [Header("Camera Shake")]
    [SerializeField] public GameObject cam;
    [SerializeField] private Vector3 _ogCamPos;
    [SerializeField] private bool screenShaking;
    [SerializeField] private float _shakeStr; 

    // Start is called before the first frame update
    void Start()
    {
        _ogCamPos = cam.transform.position;
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

        if (screenShaking) 
        {
            cam.transform.position = new Vector3(_ogCamPos.x, _ogCamPos.y, _ogCamPos.z) + new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * _shakeStr;

            _shakeStr -= Time.deltaTime/2;
        }
    }



    public IEnumerator Serve()
    {


        yield return new WaitForSeconds(globalSpeedMod);
    }


    public IEnumerator ShakeCamera(float shakeDuration, float shakeStr)
    {
        if (!screenShaking)
        {
            _shakeStr = shakeStr;
            screenShaking = true;

            yield return new WaitForSeconds(shakeDuration);

            ShakeStop();
        }

    }

    private void ShakeStop()
    {

        screenShaking=false;
        cam.transform.position = _ogCamPos;
        
        
    }

    public IEnumerator FlashCity(Vector2 position)
    {
        yield return null;
    }
}
