using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public static bool loadedGame;
    /*public static void loadGame() {
        LoadWeapons();
        PlayerWeapons.LoadWeapons();
    }*/

    public static void LoadWeapons() {
        loadedGame = true;
    }
}
