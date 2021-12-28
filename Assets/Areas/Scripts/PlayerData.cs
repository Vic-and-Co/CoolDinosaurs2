using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool tutorialDone;
    public float maxHealth;

    public PlayerData (PlayerData player) {
        tutorialDone = ShipScript.tutorialDone;
        maxHealth = PlayerHealth.maxHealth;
    }
}
