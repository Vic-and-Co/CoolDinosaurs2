/*
 Movement utility (equippables)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    [SerializeField] public bool tabiOwned = false;
    [SerializeField] public bool tabiEquip;
    public static bool tabiOwn;
    public static bool tabiOn;

    [SerializeField] public bool aidsBootOwned = false;
    [SerializeField] public bool aidsBootEquip;
    public static bool aidsBootOwn;
    public static bool aidsBootOn;

    [SerializeField] public bool dashOwned = false;
    [SerializeField] public bool dashEquip;
    public static bool dashOwn;
    public static bool dashOn;

    [SerializeField] public bool grappleOwned = false;
    [SerializeField] public bool grappleEquip;
    public static bool grappleOwn;
    public static bool grappleOn;

    //Value Adder
    [SerializeField] public int aidsBootBoost;
    public static int aidsBootSpeed;

    void Update()
    {
        //Checker
        checkOwned();

        //Relay
        relayItems();
        relayModifiers();
    }

    private void checkOwned() {
        if (!tabiOwned) {
            tabiEquip = false;
        }

        if (!aidsBootOwned) {
            aidsBootEquip = false;
        }

        if (!dashOwned) {
            dashEquip = false;
        }

        if (!grappleOwned) {
            grappleEquip = false;
        }
    }

    /* For Utility DropDown menu */

    //Aids Boots
    public void toggleAids() {
        if (aidsBootOwned) {
            if (aidsBootEquip) {
                aidsBootEquip = false;
            }
            else {
                aidsBootEquip = true;
            }
        }
    }

    //Tabi Boots
    public void toggleTabi() {
        if (tabiOwned) {
            if (tabiEquip) {
                tabiEquip = false;
            }
            else {
                tabiEquip = true;
            }
        }
    }

    //Grappler
    public void toggleGrapple() {
        if (grappleOwned) {
            if (grappleEquip) {
                grappleEquip = false;
            }
            else {
                grappleEquip = true;
            }
        }
    }

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

        tabiOn = tabiEquip;
        aidsBootOn = aidsBootEquip;
        dashOn = dashEquip;
        grappleOn = grappleEquip;
    }

    private void relayModifiers() {
        if (aidsBootEquip) {
            aidsBootSpeed = aidsBootBoost;
        } else {
            aidsBootSpeed = 0;
        }
    }
}
