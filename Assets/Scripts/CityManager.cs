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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        print("City Destroyed!");
    }


}
