using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject ship;
    public static bool tutorialDone;


    public void Start() {
        //mouseText.SetActive(false);
        LoadTutorialDone();
        if (tutorialDone) {
            WorldManager.currentGameWorld = "MainHub";
            PlayerMovement.teleportPlayer();
            MouseFollower.isShown = false;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnMouseOver() {
        MouseFollower.isShown = true;
        if (DummyScript.stepFiveIntro) {
            MouseFollower.mouseText = "["+PlayerMovement.interectKey+"] Leave";
            if(Input.GetKeyDown(PlayerMovement.interectKey) && !CharMenu.open) {
                WorldManager.currentGameWorld = "MainHub";
                PlayerMovement.teleportPlayer();
                MouseFollower.isShown = false;

                tutorialDone = true;
            }

        } else {
            MouseFollower.mouseText = "Can't Currently Access.";
        }
    }

    public void OnMouseExit() {

        MouseFollower.isShown = false;
    }

    public void SaveTutorialDone() {
        SaveSystem.SaveTutorialDone(this);
    }

    public void LoadTutorialDone() {
        if (PlayerLoader.loadedGame) {
            TutorialData tutorialData = SaveSystem.LoadTutorialDone();

            tutorialDone = tutorialData.tutorialDone;
        }
    }
}
