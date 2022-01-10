using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData {
    public bool pbOwned;
    public bool pmOwned;
    public bool cgOwned;

    public WeaponData(PlayerWeapons playerWeapons) {
        pbOwned = PlayerWeapons.pbOwn;
        pmOwned = PlayerWeapons.pmOwn;
        cgOwned = PlayerWeapons.cgOwn;
    }
}