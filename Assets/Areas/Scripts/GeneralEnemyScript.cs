using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyScript : MonoBehaviour
{
    [SerializeField] private float health;

    public GameObject thisEnemy;
    public GameObject dmgText;
    public TextMesh textDmg;
    public Transform dmgArea;

    public float dmgType;

    private void Start() {
        textDmg = dmgText.GetComponentInChildren<TextMesh>();
    }
    private void Update() {
        //temp kill enemy, will destroy prefab when made into prefab
        if (health <= 0) {
            MoneyManager.addMoney(5);
            thisEnemy.SetActive(false);
        }
        print("ENEMY HEALTH IS" + health);
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
        }
        else {
            dmgType = 1;
            textDmg.color = Color.white;
        }

        switch (collision.collider.tag) {
            case "specialTinyDmgBullet":
                dmgTake = Random.Range(1, 2) * dmgType;
                health -= dmgTake;
                showDamage(dmgTake);
                break;

            case "tinyDmgBullet":
                dmgTake = Random.Range(1, 11) * dmgType;
                health -= dmgTake;
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
