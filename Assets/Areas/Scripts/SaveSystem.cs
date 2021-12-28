using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {
     public static void SaveWeapons(PlayerWeapons playerWeapons) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerWeapons.rice";
        FileStream stream = new FileStream(path, FileMode.Create);

        WeaponData weaponData = new WeaponData(playerWeapons);

        formatter.Serialize(stream, weaponData);
        stream.Close();
    }

    public static WeaponData LoadWeapons() {
        string path = Application.persistentDataPath + "/playerWeapons.rice";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WeaponData weaponData = formatter.Deserialize(stream) as WeaponData;
            stream.Close();

            return weaponData;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    public static void SaveTutorialDone(ShipScript shipScript) {
        BinaryFormatter formatterTut = new BinaryFormatter();
        string pathTut = Application.persistentDataPath + "/tutorialProgress.rice";
        FileStream streamTut = new FileStream(pathTut, FileMode.Create);

        TutorialData tutorialData = new TutorialData(shipScript);

        formatterTut.Serialize(streamTut, tutorialData);
        streamTut.Close();
    }

    public static TutorialData LoadTutorialDone() {
        string pathTut = Application.persistentDataPath + "/tutorialProgress.rice";
        if (File.Exists(pathTut)) {
            BinaryFormatter formatterTut = new BinaryFormatter();
            FileStream streamTut = new FileStream(pathTut, FileMode.Open);

            TutorialData tutorialData = formatterTut.Deserialize(streamTut) as TutorialData;
            streamTut.Close();

            return tutorialData;
        }
        else {
            Debug.LogError("Save file for tutorial not found in " + pathTut);
            return null;
        }
    }
} 
