/*
 Movement utility (equippables)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    [SerializeField] public bool tabiOwned = false;
    public static bool tabiOwn;

    [SerializeField] public bool aidsBootOwned = false;
    public static bool aidsBootOwn;

    [SerializeField] public bool dashOwned = false;
    public static bool dashOwn;

    [SerializeField] public bool grappleOwned = false;
    public static bool grappleOwn;

    //Value Adder
    [SerializeField] public int aidsBootBoost;
    public static int aidsBootSpeed;

    void Update()
    {
        //Checker
        //checkOwned();

        //Relay
        relayItems();
        relayModifiers();
    }


    /* For Utility DropDown menu */


    /*DEBUG*/
    public void ownEverything() {
        tabiOwned = true;
        aidsBootOwned = true;
        grappleOwned = true;
    }

    /*Tools Allowed Relay*/
    public static void ownAidsBoots() {
        //aidsBootOwned = true;
    }

    /* Relay */
    private void relayItems() {
        tabiOwn = tabiOwned;
        aidsBootOwn = aidsBootOwned;
        dashOwn = dashOwned;
        grappleOwn = grappleOwned;
    }

    private void relayModifiers() {
        if (aidsBootOwned) {
            aidsBootSpeed = aidsBootBoost;
        } else {
            aidsBootSpeed = 0;
        }
    }
}
