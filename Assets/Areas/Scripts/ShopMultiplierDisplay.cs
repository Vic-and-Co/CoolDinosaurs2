using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMultiplierDisplay : MonoBehaviour
{
    public Text tabiMultiplier;

    private void Update() {
        updateValue();
    }

    private void updateValue() {
        tabiMultiplier.text = "x" + PlayerTools.boostJump;
    }
}
