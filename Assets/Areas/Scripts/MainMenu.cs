using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject mainMenu;

    public void Start() {
        mainMenu.SetActive(true);
    }

    public void enterIntro() {
        SceneManager.LoadScene("IntroText");
    }
}
