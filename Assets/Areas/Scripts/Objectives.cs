using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public TMP_Text objective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(PlayerWeapons.pbOwn);
        if (PlayerWeapons.pbOwn == true) {
            objective.text = "lol. Press tab to open your character menu, click on weapons and equip the PissBaby.";

            if(Primary.primarySelect == "PissBaby" || Secondary.secondarySelect == "PissBaby") {
                objective.text = "Neat. Now go right.";
            }
        }
    }
}
