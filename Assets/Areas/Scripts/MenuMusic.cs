using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public GameObject musicManager;
    public AudioSource fridayNight;

    void Start()
    {
        //Invoke("musicContinue", 7.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)) {
            //skip to 7.8f of song
            fridayNight.time = 7.75f;
        }

        if (SceneManager.GetActiveScene().name == "MainArea" ) {
            Destroy(musicManager);
        }
    }
}
