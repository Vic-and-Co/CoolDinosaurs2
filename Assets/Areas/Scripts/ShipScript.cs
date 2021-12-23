using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject ship;
    //public GameObject mouseText;

    public void Start() {
        //mouseText.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnMouseOver() {
        MouseFollower.isShown = true;
        if (DummyScript.stepFiveIntro) {
            MouseFollower.mouseText = "Leave";
            if(Input.GetMouseButtonDown(0) && !CharMenu.open) {
                WorldManager.currentGameWorld = "MainHub";
                PlayerMovement.teleportPlayer();
                MouseFollower.isShown = false;
            }

        } else {
            MouseFollower.mouseText = "Can't Currently Access.";
        }
    }

    public void OnMouseExit() {

        MouseFollower.isShown = false;
    }
}
