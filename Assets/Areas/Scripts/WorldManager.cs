using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject background;

    //Declare worlds
    public GameObject TutorialWorld;
    public GameObject MainHub;
    public GameObject Plains;

    //Background sprites
    public Sprite forestBG;
    public Sprite mountainsBG;

    public static string currentGameWorld = "TutorialArea";

    public void Start() {
        MainHub.SetActive(false);
        TutorialWorld.SetActive(true);
    }

    public void Update() {
        checkWorld();
    }

    public void checkWorld() {
        if (currentGameWorld == "TutorialArea") { TutorialWorld.SetActive(true); } else { TutorialWorld.SetActive(false); }
        if (currentGameWorld == "MainHub") { MainHub.SetActive(true); } else { MainHub.SetActive(false); }
        if (currentGameWorld == "Plains") { Plains.SetActive(true); } else { Plains.SetActive(false); }

    }
    
    public void goToHub() {
        currentGameWorld = "MainHub";
        background.GetComponent<SpriteRenderer>().sprite = forestBG;
        PlayerMovement.teleportPlayer();
    }

    public void goToPlains() {
        currentGameWorld = "Plains";
        background.GetComponent<SpriteRenderer>().sprite = mountainsBG;
        PlayerMovement.teleportPlayer();
    }
}
