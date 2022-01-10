using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject shopCab;
    public GameObject shopMenu;

    public static bool shopOpen;

    void Start()
    {
        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkShopOpen();
    }

    public void OnMouseExit() {

        MouseFollower.isShown = false;
    }

    public void OnMouseOver() {
        MouseFollower.mouseText = "[" + PlayerMovement.interectKey + "] Shop";
        MouseFollower.isShown = true;
        if (Input.GetKeyDown(PlayerMovement.interectKey)) {
            shopOpen = true;
        }
        
    }

    public void checkShopOpen() {
        if (shopOpen) {
            shopMenu.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Escape)) { shopOpen = false; }
        } else { shopMenu.SetActive(false); Time.timeScale = 1f; }
    }
}
