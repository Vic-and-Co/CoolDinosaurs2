using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    public GameObject textToFollow;
    Vector3 mousePos;
    Vector2 position = new Vector2(0f, 0f);
    public float originalZ;
    public static string mouseText = "joe";

    public static bool isShown;

    void Start() {
        originalZ = textToFollow.GetComponent<Transform>().position.z;
        //textToFollow.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        updatePos();
        updateText();
        textVisibility();
    }

    private void updatePos() {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        textToFollow.GetComponent<Transform>().position = mousePos;
        textToFollow.GetComponent<Transform>().position = new Vector3(textToFollow.GetComponent<Transform>().position.x, textToFollow.GetComponent<Transform>().position.y + 0.5f, originalZ);
    }

    public void updateText() {
        textToFollow.GetComponent<TextMesh>().text = mouseText;
    }

    public void textVisibility() {
        if (isShown) {
            textToFollow.SetActive(true);
        } else {
            textToFollow.SetActive(false);
        }
    }
}
