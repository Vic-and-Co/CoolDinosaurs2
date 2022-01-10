/*
 Movement utility (equippables)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public static bool tabiOwn = false;

    public static bool aidsBootOwn = false;

    public static bool dashOwn = false;

    public static bool grappleOwn = false;

    //Value Adder
    public static int aidsBootSpeed;
    public static int boostJump = 0;

    void Update()
    {
        //Checker
        //checkOwned();

        //Relay
        relayModifiers();
    }


    /* For Utility DropDown menu */


    /*DEBUG*/
    public void ownEverything() {
        tabiOwn = true;
        aidsBootOwn = true;
        grappleOwn = true;
    }

    /*Tools Allowed Relay*/
    public static void ownAidsBoots() {
        //aidsBootOwned = true;
    }

    /* Relay */
    private void relayModifiers() {
        if (aidsBootOwn) {
            aidsBootSpeed = 10;
        } else {
            aidsBootSpeed = 0;
        }
    }

    public static void buyTabi() {
        if (MoneyManager.thonDollars >= 10) {
            if (!tabiOwn) {
                tabiOwn = true;
                boostJump++;
                MoneyManager.addMoney(-10);
            }
            else {
                boostJump++;
                MoneyManager.addMoney(-10);
            }
        }
    }

    public static void sellTabi() {
        if (boostJump > 0) {
            boostJump--;
            MoneyManager.addMoney(5);
        }
    }
}
