using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth;

    public void takeDmg(int dmg)
    {
        currentHealth -= dmg;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void setHealth(int health)
    {
        currentHealth = health;
        this.slider.value = health;
        if (health < 0) {
            //death(); 
            GameManager.Instance.changeState(GameManager.GameState.Lost);
        }
    }

    public void death()
    {
        
    }

    void Update()
    {
        //if (currentHealth > 100) currentHealth += 1 * Time.deltaTime;
        this.setHealth(currentHealth);
    }
}

