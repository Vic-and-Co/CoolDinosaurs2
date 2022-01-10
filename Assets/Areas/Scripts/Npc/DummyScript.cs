using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private int health = 20;

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
        if (health <= 0) {
            dropPissMan();
            stepFiveIntro = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "tinyDmgBullet") {
            int dmgTake = Random.Range(1, 11);
            showDamage(dmgTake);
            health -= dmgTake;

        }
    }

    private void dropPissMan() {
        Instantiate(pissMan, dropPlace.position, dropPlace.rotation);
    }

    public void showDamage(int dmgStrength) {
        if (dmgText) {
            GameObject prefab = Instantiate(dmgText, dmgArea.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = dmgStrength.ToString();
            Destroy(prefab, 0.65f);
        }
    }
}
