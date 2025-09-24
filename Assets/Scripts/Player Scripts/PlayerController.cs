using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AbilityManager abilityManager;

    Rigidbody2D rb;

    public string inputAxis;

    [SerializeField] private float moveSpeed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print("Rigidbody Recieved: " + rb);
        abilityManager = GetComponentInChildren<AbilityManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(abilityManager.WallAbility());
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(abilityManager.GrabAbility());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX, moveY)*moveSpeed;

    }
}
