using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;
    public Image imageHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();

        if(currentHealth <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void CheckHealth() {
        imageHealthBar.fillAmount = currentHealth / maxHealth;
    }
}
