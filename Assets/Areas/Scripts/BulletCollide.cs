using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Barrier") {
            Destroy(gameObject);
        }
    }
}
