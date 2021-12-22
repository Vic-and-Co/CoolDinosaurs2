using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    public void Update() {
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag != "Player") {
            if (collision.collider.tag == "Dummy") {
                Destroy(gameObject, 1);

            } else {
                Destroy(gameObject);
            }
        }
    }

    
}
