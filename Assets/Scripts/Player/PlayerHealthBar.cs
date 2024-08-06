using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;

    public static PlayerHealthBar instance;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);    
        }



    }


    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
