using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerWeapons : MonoBehaviour
{
    //[SerializeField] public bool pbOwned = false;
    public static bool pbOwn = false;

    //[SerializeField] public bool pmOwned = false;
    public static bool pmOwn;


    public TMP_Dropdown primaryDropdown;
    public TMP_Dropdown secondaryDropdown;

    public static TMP_Dropdown primaryDropd;
    public static TMP_Dropdown secondaryDropd;

    public static int PST_select; //Primary 0, secondary 1, trinary 2

    public static HashSet<string> primarySecondaryOptions = new HashSet<string>();
    private void Awake() {
    }

    private void Start() {

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
        primaryDropd.options.Add(new TMP_Dropdown.OptionData() { text = item });
        secondaryDropd.options.Add(new TMP_Dropdown.OptionData() { text = item });
    }

    public void checkOwned() {
        
    }

    /*Relay*/
    private void relayWeapons() {
        //pbOwn = pbOwned;
        //pmOwn = pmOwned;
    }
}
