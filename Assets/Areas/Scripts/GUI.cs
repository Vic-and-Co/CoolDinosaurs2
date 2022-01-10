using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    public GameObject gui;

    public static bool guiActive = true;

    public void Update() {
        if(CharMenu.open || LocationMenu.open) {
            guiActive = false;
        } else { guiActive = true; }

        if(guiActive) {
            gui.SetActive(true);
        } else { gui.SetActive(false); }
    }
}
