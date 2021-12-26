using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public GameObject musicManager;

    void Start()
    {
        //Invoke("musicContinue", 7.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainArea" ) {
            Destroy(musicManager);
        }
    }
}
