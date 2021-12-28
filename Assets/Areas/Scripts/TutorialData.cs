using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialData {
    public bool tutorialDone;

    public TutorialData(ShipScript shipScript) {
        tutorialDone = ShipScript.tutorialDone;
    }
}