using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] string gameScene;

    [SerializeField] TMP_Text _titleTop;
    [SerializeField] TMP_Text _titleBot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit the game");
    }


    public void Secret()
    {
        _titleTop.alignment = TextAlignmentOptions.Center;
        _titleTop.enableWordWrapping = false;
        _titleTop.text = "assignment:";

        _titleBot.alignment = TextAlignmentOptions.Center;
        _titleBot.enableWordWrapping = false;
        _titleBot.text = "theory";
    }
}
