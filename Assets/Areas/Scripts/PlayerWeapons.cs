using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] public bool pbOwned = false;
    public bool pbOwn;

    [SerializeField] public bool pmOwned = false;
    public bool pmOwn;



    public static int PST_select; //Primary 0, secondary 1, trinary 2
    

    private void Awake() {
    }

    private void Start() {

    }

    void Update() {
        relayWeapons();
        currentSelect();

        /*foreach(var item in primarySecondaryOptions) {
            print(item);
        }*/

        //print("Current select is "+ PST_select);


        //print(primaryDropdown.options[primaryDropdown.value].text);
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


    /*Relay*/
    private void relayWeapons() {
        pbOwn = pbOwned;
        pmOwn = pmOwned;
    }
}
