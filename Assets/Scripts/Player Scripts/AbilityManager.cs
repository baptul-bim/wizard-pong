using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    [Header("Wall Ability")]
    [SerializeField] GameObject wallPrefab;
    [SerializeField] private float wallDuration;
    [SerializeField] private float wallOffset;
    [SerializeField] private float wallCd = 0.5f;
    [SerializeField] private float wallTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wallTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && wallTimer >= wallCd)
        {
            print("wall button pressed");

            GameObject wallInstance;

            wallInstance = Instantiate(wallPrefab, new Vector2(this.transform.position.x + wallOffset, this.transform.position.y), this.transform.rotation);

            Rigidbody shotRB = wallInstance.GetComponent<Rigidbody>();
            //  shotInstance.GetComponent<Rigidbody>().AddForce(shotInstance.transform.forward * shotSpeed, 1, 1);

            //shotRB.AddForce(gameObject.transform.forward * shotSpeed);

            wallTimer = 0;

            Destroy(wallInstance, wallDuration);
        }
    }
}
