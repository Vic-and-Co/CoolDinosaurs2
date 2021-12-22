using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private float health = 30;
    public GameObject healthbar;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;

    public GameObject pissMan;
    public Transform dropPlace;

    public Transform dummy;
    public GameObject dmgText;
    public Transform dmgArea;

    public static bool stepFiveIntro;
    public Vector3 spawnPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        healthCheck();
        //public Vector3 spawnPos = transform.position;
        spawnPos = new Vector3(0, 0, 0);
    }

    private void healthCheck() {
        if (health == 30) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
        }
        else if (health == 20) {
            healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
        }
        else if (health == 10) {
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
            showDamage(10);
            health -= 10;

        }
    }

    private void dropPissMan() {
        Instantiate(pissMan, dropPlace.position, dropPlace.rotation);
    }

    public void showDamage(float dmgStrength) {
        if (dmgText) {
            GameObject prefab = Instantiate(dmgText, dmgArea.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = dmgStrength.ToString();
            Destroy(prefab, 0.65f);
        }
    }
}
