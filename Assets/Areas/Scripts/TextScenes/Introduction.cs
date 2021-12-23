using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    private int currentText = 0;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;

    // Start is called before the first frame update
    void Start()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            currentText++;
        }
        updateTxt();

        if (Input.GetKeyDown(KeyCode.Space) || 
            Input.GetKeyDown(KeyCode.Escape)) {
            endIntro();
        }
    }

    private void updateTxt() {
        if (currentText == 0) {
            p1.SetActive(true);
        } else if (currentText == 1) {
            p1.SetActive(false);
            p2.SetActive(true);
        } else if (currentText == 2) {
            p2.SetActive(false);
            p3.SetActive(true);
        } else if (currentText == 3) {
            p3.SetActive(false);
            p4.SetActive(true);
        } else if (currentText == 4) {
            p4.SetActive(false);
            p5.SetActive(true);
        } else if (currentText >= 5) {
            p5.SetActive(false);
            WorldManager.currentGameWorld = "TutorialArea";
            SceneManager.LoadScene("MainArea");

        }
    }

    private void endIntro() {
        currentText = 5;
    }
}
