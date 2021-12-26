using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject startButton;

    public void Start() {
        mainMenu.SetActive(true);
        DontDestroyOnLoad(startButton);
        //SceneManager.UnloadSceneAsync("IntroText");
    }

    public void enterIntro() {
        mainMenu.SetActive(false);
        SceneManager.LoadScene("IntroText");
    }

    public void printTest() {
        print("Bruhhhhh");
    }
}
