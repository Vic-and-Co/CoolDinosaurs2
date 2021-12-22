using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;

    float health, maxHealth = 100;
    float lerpSpeed;

    private void Start() {
        health = maxHealth;
    }

    private void Update() {
        healthText.text = health + "%";
        lerpSpeed = 3f * Time.deltaTime;

        healthBarFiller();
        colorChange();
    }

    void healthBarFiller() {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void colorChange() {
        Color healthColor = Color.Lerp(Color.red, Color.green, health / maxHealth);
        healthBar.color = healthColor;
    }

    public void playerDamage(float damagePoints) {
        if(health > 0) {
            health -= damagePoints;
        }
    }

    public void playerHeal(float healPoints) {
        if (health < maxHealth) {
            health += healPoints;
        }
    }
}
