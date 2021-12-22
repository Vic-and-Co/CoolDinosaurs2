using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /*Shooty Wooty*/

    //Shooter
    public Transform pissBaby;
    public GameObject pissBabyObj;
    public Transform pissMan;
    public GameObject pissManObj;

    //Shooted
    public GameObject pb_bullet;
    public GameObject pm_bullet;

    //Shoot at
    public Transform pb_shootPoint;
    public Transform pm_shootPoint;

    //Shoot Values
    private float pb_nextFireTime;
    private float pb_coolDownTime = 0.5f;

    private float pm_nextFireTime;
    private float pm_coolDownTime = 0.2f;

    Vector2 direction;
    void Start()
    {
        
    }


    void Update() {
        faceMouse(pissBaby);
        faceMouse(pissMan);

        if (PlayerWeapons.PST_select == 0) { //Accounts for primary selected

            if (Primary.primarySelect == "PissBaby") {
                pissBabyObj.SetActive(true);
                if (Time.time > pb_nextFireTime) {
                    if (Input.GetMouseButtonDown(0)) {
                        pb_nextFireTime = Time.time + pb_coolDownTime;
                        shoot(pb_bullet, 1200);
                    }
                }
            } else { pissBabyObj.SetActive(false); }

            if (Primary.primarySelect == "PissMan") {
                pissManObj.SetActive(true);
                if (Time.time > pm_nextFireTime) {
                    if (Input.GetMouseButton(0)) {
                        pm_nextFireTime = Time.time + pm_coolDownTime;
                        shoot(pm_bullet, 1200);
                    }
                }
            } else  { pissManObj.SetActive(false); }
        }

        if (PlayerWeapons.PST_select == 1) { //Accounts for secondary selected

            if (Secondary.secondarySelect == "PissBaby") {
                pissBabyObj.SetActive(true);
                if (Time.time > pb_nextFireTime) {
                    if (Input.GetMouseButtonDown(0)) {
                        pb_nextFireTime = Time.time + pb_coolDownTime;
                        shoot(pb_bullet, 1500);
                    }
                }
            } else { pissBabyObj.SetActive(false); }

            if (Secondary.secondarySelect == "PissMan") {
                pissManObj.SetActive(true);
                if (Time.time > pm_nextFireTime) {
                    if (Input.GetMouseButton(0)) {
                        pm_nextFireTime = Time.time + pm_coolDownTime;
                        shoot(pm_bullet, 1500);
                    }
                }
            } else { pissManObj.SetActive(false); }
        }
    }

    void faceMouse(Transform gun) {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)gun.position;

        gun.transform.right = direction;

    }

    void shoot(GameObject bullet, float bulletSpeed) {
        GameObject BulletIns = Instantiate(bullet, pb_shootPoint.position, pb_shootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletSpeed);
        Destroy(BulletIns, 3);
    }

}
