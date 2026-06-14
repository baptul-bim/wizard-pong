using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    [SerializeField] float cityHealth;
    [SerializeField] float cityShield;
    [SerializeField] Slider cityHealthSlider;
    [SerializeField] Slider cityShieldSlider;
    [SerializeField] GameManager gameManager;

    [SerializeField] public SpriteRenderer flash;

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

        StartCoroutine(gameManager.FlashCamera(flash));
        if (cityShield > 0)
        {
            cityShield -= damage;
            cityShieldSlider.value = cityShield;
            StartCoroutine(gameManager.ShakeCamera(0.5f, 0.3f));
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

    }

    public void DestroyCity()
    {
        StartCoroutine(gameManager.ShakeCamera(1, 0.5f));
        print("City Destroyed!");

        StartCoroutine(GameOver());
    }


    public IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene("MenuScene");
    }


}
