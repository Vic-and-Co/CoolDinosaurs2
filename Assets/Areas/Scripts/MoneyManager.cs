using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text money;
    public static int thonDollars;

    private void Start() {
        money.text = "$" + thonDollars;
    }

    private void Update() {
        money.text = "$" + thonDollars;
    }

    public static void addMoney(int amt) {
        thonDollars += amt;
    }
}
