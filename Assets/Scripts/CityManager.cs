using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    [SerializeField] float cityHealth;
    [SerializeField] float cityShield;
    [SerializeField] Slider cityHealthSlider;
    [SerializeField] Slider cityShieldSlider;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(gameManager.ShakeCamera(5, 1));
        }
        /*
        cityHealthSlider.value = cityHealth;
        cityShieldSlider.value = cityShield;
        */
    }

    public void DamageCity(float damage)
    {
        print(damage);
        if (cityShield > 0)
        {
            cityShield -= damage;
            cityShieldSlider.value = cityShield;
        }
        else if (cityHealth > 0)
        {
            cityHealth -= damage;
            cityHealthSlider.value = cityShield;
        }

        if (cityHealthSlider.value <= 0)
        {
            DestroyCity();
        }

        GameManager.globalSpeedMod = 1;
    }

    public void DestroyCity()
    {
        StartCoroutine(gameManager.ShakeCamera(1, 0.5f));
        print("City Destroyed!");
    }


}
