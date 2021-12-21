using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private int health = 3;
    public GameObject healthbar;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;

    public GameObject pissMan;
    public Transform dropPlace;

    public static bool stepFiveIntro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        healthCheck();
    }

    private void healthCheck() {
        if (health == 3) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
        }
        else if (health == 2) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
        }
        else if (health == 1) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
        }
        else if (health == 0) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health0;
            dropPissMan();
            stepFiveIntro = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "pb_bullet") {
            health--;
        }
    }

    private void dropPissMan() {
        Instantiate(pissMan, dropPlace.position, dropPlace.rotation);
    }
}
