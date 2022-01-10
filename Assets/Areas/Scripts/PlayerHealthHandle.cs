using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandle : MonoBehaviour
{
    private bool dmgAllow;

    public float coolDownTime = 1;
    private float nextDmgTime = 0;

    private void Update() {
        if (Time.time > nextDmgTime) {
            dmgAllow = true;
        } else { dmgAllow = false; }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (PlayerHealth.health > 0 & dmgAllow) {
            switch (collision.collider.tag) {
                case "tinyEnemy":
                    PlayerHealth.health -= 5;
                    break;
            }
            nextDmgTime = Time.time + coolDownTime;
        }
    }
}
