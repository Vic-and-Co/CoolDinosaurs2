using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMenu : MonoBehaviour
{
    public GameObject charMenu;

    public KeyCode charMenuKey = KeyCode.Tab;

    public bool paused;

    void Start()
    {
        charMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        menu();
    }

    public void openMenu() {
        charMenu.SetActive(true);
        paused = true;

        //Time.timeScale = 0f;
    }

    public void closeMenu() {
        charMenu.SetActive(false);
        paused = false;

        //Time.timeScale = 1f;
    }

    public void menu() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (paused) {
                closeMenu();
            } else if (!paused) {
                openMenu();
            }
        }
    }
}
