using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDummyScript : MonoBehaviour {
    [SerializeField] private int health = 20000;

    public Transform dummy;
    public GameObject dmgText;
    public TextMesh textDmg;

    public Transform dmgArea;


    public static bool stepFiveIntro;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    public float dmgType; //multiplier

    // Start is called before the first frame update
    void Start() {
        textDmg = dmgText.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update() {
        //public Vector3 spawnPos = transform.position;
        spawnPos = new Vector3(0, 0, 0);
    }

    public void OnMouseExit() {

        MouseFollower.isShown = false;
    }

    public void OnMouseOver() {
        MouseFollower.mouseText = "Test Dummy";
        MouseFollower.isShown = true;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        float dmgTake;
        int isCrit = Random.Range(1, 101);
        if (isCrit <= 10) {
            //small crit
            dmgType = 1.5f;
            textDmg.color = Color.yellow;
            if (isCrit == 1) {
                //big crit
                dmgType = 2;
                textDmg.color = Color.red;
            }
        } else {
            dmgType = 1;
            textDmg.color = Color.white;
        }

        switch(collision.collider.tag) {
            case "specialTinyDmgBullet":
                dmgTake = Random.Range(1, 2) * dmgType;
                showDamage(dmgTake);
                break;

            case "tinyDmgBullet":
                dmgTake = Random.Range(1, 11) * dmgType;
                showDamage(dmgTake);
                break;
        }
    }

    public void showDamage(float dmgStrength) {
        if (dmgText) {
            GameObject prefab = Instantiate(dmgText, dmgArea.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = dmgStrength.ToString();
            Destroy(prefab, 0.65f);
        }
    }
}
