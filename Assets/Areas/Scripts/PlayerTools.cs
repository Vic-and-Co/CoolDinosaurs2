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
    public static bool tabiOn;

    [SerializeField] public bool aidsBootOwned = false;
    [SerializeField] public bool aidsBootEquip;
    public static bool aidsBootOn;

    [SerializeField] public bool dashOwned = false;
    [SerializeField] public bool dashEquip;
    public static bool dashOn;

    [SerializeField] public bool grappleOwned = false;
    [SerializeField] public bool grappleEquip;
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

    private void relayItems() {
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
