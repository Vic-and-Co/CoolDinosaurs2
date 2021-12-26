using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMenu : MonoBehaviour
{
    public GameObject charMenu;
    public GameObject utilDrop;
    public GameObject weaponDrop;

    public KeyCode charMenuKey = KeyCode.Tab;

    public static bool open;
    public bool utilDropped;
    public bool weapDropped;

    void Start()
    {
        charMenu.SetActive(false);
        utilDrop.SetActive(false);
        weaponDrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        menu();
    }

    public void openMenu() {
        charMenu.SetActive(true);
        GUI.guiActive = false;
        Objectives.objectiveActive = false;
        open = true;

        //Time.timeScale = 0f;
    }

    public void closeMenu() {
        charMenu.SetActive(false);
        GUI.guiActive = true;
        Objectives.objectiveActive = true;
        open = false;

        //Time.timeScale = 1f;
    }

    public void menu() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (open) {
                closeMenu();
            } else {
                openMenu();
            }
        }
    }

    public void toggleUtilDrop() {
        if (utilDropped) {
            print("util drop");
            utilDrop.SetActive(false);
            utilDropped = false;
        } else {
            utilDrop.SetActive(true);
            utilDropped = true;
            if (weapDropped) {
                weaponDrop.SetActive(false);
                weapDropped = false;
            }
        }
    }

    public void toggleWeaponDrop() {
        if (weapDropped) {
            weaponDrop.SetActive(false);
            weapDropped = false;
        }
        else {
            weaponDrop.SetActive(true);
            weapDropped = true;
            if (utilDropped) {
                utilDrop.SetActive(false);
                utilDropped = false;
            }
        }
    }

    /*Allow to equip*/

}
