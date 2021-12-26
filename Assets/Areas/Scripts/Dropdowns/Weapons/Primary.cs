using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Primary : MonoBehaviour
{
    int primLayer;
    public Dropdown primaryDropdown;

    public static string primarySelect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        primarySelect = primaryDropdown.options[primaryDropdown.value].text;

    }
}
