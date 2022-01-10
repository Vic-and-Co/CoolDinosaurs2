using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMenu : MonoBehaviour
{
    public GameObject locationMenu;
    public static bool open;

    private void Start() {
        locationMenu.SetActive(false);
    }

    private void Update() {
        menu();
    }

    public void mapHandle() {
        if (open) {
            CharMenu.open = false;
            locationMenu.SetActive(true);
            GUI.guiActive = false;
            Objectives.objectiveActive = false;
            ShopScript.shopOpen = false;
        } else {
            locationMenu.SetActive(false);
            //Objectives.objectiveActive = true;
            open = false;
        }
    }

    public void menu() {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (open) {
                open = false;
            }
            else {
                open = true;
            }
        }
        mapHandle();
    }
}
