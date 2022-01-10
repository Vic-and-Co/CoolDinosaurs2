using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerWeapons : MonoBehaviour
{
    public static bool pbOwn;
    public static bool pmOwn;
    public static bool cgOwn;


    public Dropdown primaryDropdown;
    public Dropdown secondaryDropdown;

    public static Dropdown primaryDropd;
    public static Dropdown secondaryDropd;

    public static int PST_select; //Primary 0, secondary 1, trinary 2

    public static HashSet<string> primarySecondaryOptions = new HashSet<string>();

    private void Awake() {

    }

    private void Start() {
        //LoadWeapons();
        //primarySecondaryOptions.Clear();
    }

    void Update() {
        relayWeapons();
        currentSelect();

        /*if(pbOwn) {
            primaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "PissBaby" });
        }*/

        //print("Current select is "+ PST_select);


        //print(primaryDropdown.options[primaryDropdown.value].text);

        primaryDropd = primaryDropdown;
        secondaryDropd = secondaryDropdown;
    }

    public void currentSelect() {
        if (Input.GetKeyDown("1")) {
            PST_select = 0;
        } else if (Input.GetKeyDown("2")) {
            PST_select = 1;
        } else if (Input.GetKeyDown("3")) {
            PST_select = 2;
        }
    }

    public static void addWeapon(string item) {
        //if (!primarySecondaryOptions.Contains(item)) {
            primaryDropd.options.Add(new Dropdown.OptionData() { text = item });
            secondaryDropd.options.Add(new Dropdown.OptionData() { text = item });

            primarySecondaryOptions.Add(item);
        //}
    }

    public void SaveWeapons() {
        SaveSystem.SaveWeapons(this);
    }

    public void LoadWeapons() {
        if (PlayerLoader.loadedGame) {
            WeaponData weaponData = SaveSystem.LoadWeapons();

            pbOwn = weaponData.pbOwned;
            if (weaponData.pbOwned) { addWeapon("PissBaby"); }

            pmOwn = weaponData.pmOwned;
            if (weaponData.pmOwned) { addWeapon("PissMan"); }

            cgOwn = weaponData.cgOwned;
            if (weaponData.cgOwned) { addWeapon("CockGun"); }
        }
    }

    /*Relay*/
    private void relayWeapons() {
    }
}
