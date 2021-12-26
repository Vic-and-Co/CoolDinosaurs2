using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject firstPart, theLong, awaited, sequel;
    public GameObject secondPart, cool, dinosaurs, two;
    public GameObject thirdPart, a, twoD, platformer, parenths;

    public GameObject musicManager;

    private void Awake() {
        firstPart.SetActive(true);
            theLong.SetActive(false);
            awaited.SetActive(false);
            sequel.SetActive(false);

        secondPart.SetActive(true);
            cool.SetActive(false);
            dinosaurs.SetActive(false);
            two.SetActive(false);

        thirdPart.SetActive(true);
            a.SetActive(false);
            twoD.SetActive(false);
            platformer.SetActive(false);
            parenths.SetActive(false);
    }
    void Start()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.UnloadSceneAsync("IntroText");
        StartCoroutine(introAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)) {
            Invoke("musicContinue", 0f);
        }
    }

    IEnumerator introAnim() {
        theLong.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        awaited.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        sequel.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        firstPart.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        cool.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        cool.SetActive(false);
        dinosaurs.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        dinosaurs.SetActive(false);
        two.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        secondPart.SetActive(false);
        a.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        twoD.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        platformer.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        parenths.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        thirdPart.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
        DontDestroyOnLoad(musicManager);
    }

    private void musicContinue() {
        SceneManager.LoadScene("MainMenu");
        DontDestroyOnLoad(musicManager);
    }
}
