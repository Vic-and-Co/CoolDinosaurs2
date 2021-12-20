using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private string item;

    public GameObject weapon;

    public TMP_Dropdown primaryDropdown;
    public TMP_Dropdown secondaryDropdown;

    List<string> primarySecondaryOptions = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //primarySecondaryOptions.Add("Bruh");
        //updateWeaponList();
        //primaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "Bruh" });
        //secondaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "Bruh" });
    }

    // Update is called once per frame
    void Update()
    {
        print(primaryDropdown.options[primaryDropdown.value].text);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            print("TOUCHING");
            pickUp(item);
            weapon.SetActive(false);
        }
    }

    public void pickUp(string item) {
        primaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        secondaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
    }
}
