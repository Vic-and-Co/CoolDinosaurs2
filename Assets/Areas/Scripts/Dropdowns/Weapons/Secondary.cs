using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Secondary : MonoBehaviour
{
    int secLayer;
    public TMP_Dropdown secondaryDropdown;

    public static string secondarySelect;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    void Update() {
        secondarySelect = secondaryDropdown.options[secondaryDropdown.value].text;
    }

}
