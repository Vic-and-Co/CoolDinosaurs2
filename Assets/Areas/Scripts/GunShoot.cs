using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /*Shooty Wooty*/

    //Shooter
    public Transform pissBaby; //pb
    public GameObject pissBabyObj;
    public Transform pissMan; //pm
    public GameObject pissManObj;
    public Transform cockGun; //cg
    public GameObject cockGunObj;

    //Shooted
    public GameObject pb_bullet;
    public GameObject pm_bullet;
    public GameObject cg_bullet;

    //Shoot at
    public Transform pb_shootPoint;
    public Transform pm_shootPoint;
    public Transform cg_shootPoint;

    //Shoot Values
    private float pb_nextFireTime;
    private float pb_coolDownTime = 0.5f;

    private float pm_nextFireTime;
    private float pm_coolDownTime = 0.2f;

    private float cg_nextFireTime;
    private float cg_coolDownTime = 0.04f;

    public AudioSource gunHolder;
    public AudioClip pb_shootSound;
    public AudioClip pm_shootSound;
    public AudioClip cg_shootSound;

    Vector2 direction;
    void Start()
    {
        
    }


    void Update() {
        faceMouse(pissBaby);
        faceMouse(pissMan);
        faceMouse(cockGun);

        if (PlayerWeapons.PST_select == 0) { //Accounts for primary selected

            if (Primary.primarySelect == "PissBaby") {
                pissBabyObj.SetActive(true);
                if (Time.time > pb_nextFireTime) {
                    if (Input.GetMouseButtonDown(0) && !CharMenu.open) {
                        pb_nextFireTime = Time.time + pb_coolDownTime;
                        shoot(pb_bullet, 1200, pb_shootSound);
                    }
                }
            } else { pissBabyObj.SetActive(false); }

            if (Primary.primarySelect == "PissMan") {
                pissManObj.SetActive(true);
                if (Time.time > pm_nextFireTime) {
                    if (Input.GetMouseButton(0) && !CharMenu.open) {
                        pm_nextFireTime = Time.time + pm_coolDownTime;
                        shoot(pm_bullet, 1200, pm_shootSound);
                    }
                }
            } else  { pissManObj.SetActive(false); }

            if (Primary.primarySelect == "CockGun") {
                cockGunObj.SetActive(true);
                if (Time.time > cg_nextFireTime) {
                    if (Input.GetMouseButton(0) && !CharMenu.open) {
                        cg_nextFireTime = Time.time + cg_coolDownTime;
                        shoot(cg_bullet, 1200, cg_shootSound);
                    }
                }
            }
            else { cockGunObj.SetActive(false); }
        }

        if (PlayerWeapons.PST_select == 1) { //Accounts for secondary selected

            if (Secondary.secondarySelect == "PissBaby") {
                pissBabyObj.SetActive(true);
                if (Time.time > pb_nextFireTime) {
                    if (Input.GetMouseButtonDown(0) && !CharMenu.open) {
                        pb_nextFireTime = Time.time + pb_coolDownTime;
                        shoot(pb_bullet, 1500, pb_shootSound);
                    }
                }
            } else { pissBabyObj.SetActive(false); }

            if (Secondary.secondarySelect == "PissMan") {
                pissManObj.SetActive(true);
                if (Time.time > pm_nextFireTime) {
                    if (Input.GetMouseButton(0) && !CharMenu.open) {
                        pm_nextFireTime = Time.time + pm_coolDownTime;
                        shoot(pm_bullet, 1500, pm_shootSound);
                    }
                }
            } else { pissManObj.SetActive(false); }

            if (Secondary.secondarySelect == "CockGun") {
                cockGunObj.SetActive(true);
                if (Time.time > cg_nextFireTime) {
                    if (Input.GetMouseButton(0) && !CharMenu.open) {
                        cg_nextFireTime = Time.time + cg_coolDownTime;
                        shoot(cg_bullet, 1200, cg_shootSound);
                    }
                }
            }
            else { cockGunObj.SetActive(false); }
        }
    }

    void faceMouse(Transform gun) {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)gun.position;

        gun.transform.right = direction;

    }

    void shoot(GameObject bullet, float bulletSpeed, AudioClip shootSound) {
        GameObject BulletIns = Instantiate(bullet, pb_shootPoint.position, pb_shootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletSpeed);
        gunHolder.PlayOneShot(shootSound);
        Destroy(BulletIns, 3);
    }

}
