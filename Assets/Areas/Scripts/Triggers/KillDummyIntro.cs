using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* The first trigger box action */
public class KillDummyIntro : MonoBehaviour
{
    public static bool stepFourIntro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            stepFourIntro = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            stepFourIntro = true;
        }
    }
}
