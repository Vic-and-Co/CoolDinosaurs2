using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectVisual : MonoBehaviour
{
    public GameObject selector;
    public GameObject primarySelectVisual;
    public GameObject secondarySelectVisual;

    public Sprite none;
    public Sprite pissBaby;
    public Sprite pissMan;
    public Sprite cockGun;

    public void Start() {
        primarySelectVisual.GetComponent<SpriteRenderer>().sprite = pissBaby;
    }

    public void Update() {
        updateSelect();
        primarySprite();
        secondarySprite();
        
    }

    public void primarySprite() {
        switch (Primary.primarySelect) {
            case "None":
                primarySelectVisual.GetComponent<SpriteRenderer>().sprite = none;
                break;

            case "PissBaby":
                primarySelectVisual.GetComponent<SpriteRenderer>().sprite = pissBaby;
                break;

            case "PissMan":
                primarySelectVisual.GetComponent<SpriteRenderer>().sprite = pissMan;
                break;

            case "CockGun":
                primarySelectVisual.GetComponent<SpriteRenderer>().sprite = cockGun;
                break;
        }
    }

    public void secondarySprite() {
        switch (Secondary.secondarySelect) {
            case "None":
                secondarySelectVisual.GetComponent<SpriteRenderer>().sprite = none;
                break;

            case "PissBaby":
                secondarySelectVisual.GetComponent<SpriteRenderer>().sprite = pissBaby;
                break;

            case "PissMan":
                secondarySelectVisual.GetComponent<SpriteRenderer>().sprite = pissMan;
                break;

            case "CockGun":
                secondarySelectVisual.GetComponent<SpriteRenderer>().sprite = cockGun;
                break;
        }
    }

    public void updateSelect() {
        if(PlayerWeapons.PST_select == 0) {
            selector.transform.localPosition = new Vector3(-467.4f, 105f, 0);
        } else if (PlayerWeapons.PST_select == 1) {
            selector.transform.localPosition = new Vector3(-352.4f, 105f, 0);
        } else if (PlayerWeapons.PST_select == 2) {
            selector.transform.localPosition = new Vector3(-237.7001f, 105f, 0);
        }
    }
}
