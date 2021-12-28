using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public TMP_Text objective;
    public GameObject objectiveDisplay;

    public bool stepThreeIntro;
    public static bool objectiveActive;

    // Start is called before the first frame update
    void Start()
    {
        objectiveActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print(PlayerWeapons.pbOwn);
        if (objectiveActive && !ShipScript.tutorialDone) {
            objectiveDisplay.SetActive(true);
            if (PlayerWeapons.pbOwn == true) {
                objective.text = "lol. Press tab to open your character menu, click on weapons and equip the PissBaby.";

                if (Primary.primarySelect == "PissBaby" || Secondary.secondarySelect == "PissBaby" || stepThreeIntro) {
                    stepThreeIntro = true;
                    objective.text = "Neat. Now go right.";

                    if (KillDummyIntro.stepFourIntro) {
                        objective.text = "Go ahead. Murder the dummy.";

                        if (DummyScript.stepFiveIntro) {
                            objective.text = "lmao. Go to your sweet ship.";
                        }
                    }
                }
            }
        } else { objectiveDisplay.SetActive(false); objectiveActive = false; }
    }
}
