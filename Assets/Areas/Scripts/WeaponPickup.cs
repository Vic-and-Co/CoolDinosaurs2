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

    public static TMP_Dropdown primaryDrop;

    // Start is called before the first frame update
    void Start()
    {
        //primarySecondaryOptions.Add("Bruh");
        //updateWeaponList();
        //primaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "Bruh" });
        //secondaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "Bruh" });

        //primaryDropdown.options.RemoveAt(1);
        //secondaryDropdown.options.RemoveAt(1);
    }

    // Update is called once per frame
    void Update()
    {
        primaryDrop = primaryDropdown;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            pickUp(item);
            weapon.SetActive(false);
        }
    }

    public void OnMouseEnter() {
        MouseFollower.isShown = true;
        MouseFollower.mouseText = item;
    }

    public void OnMouseExit() {
        MouseFollower.isShown = false;
    }

    public void pickUp(string item) {
        if (!PlayerWeapons.primarySecondaryOptions.Contains(item)) {
            //primaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
            //secondaryDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
            PlayerWeapons.primarySecondaryOptions.Add(item);
            PlayerWeapons.addWeapon(item);
            if (item == "PissBaby") {
                PlayerWeapons.pbOwn = true;
            }
        }
    }
}
