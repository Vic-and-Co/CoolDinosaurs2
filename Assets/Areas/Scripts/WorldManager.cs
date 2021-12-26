using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    //Declare worlds
    public GameObject TutorialWorld;
    public GameObject MainHub;

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
                
    }
    
}
