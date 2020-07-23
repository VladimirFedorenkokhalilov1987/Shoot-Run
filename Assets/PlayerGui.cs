using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    public Image healthBar;

    public float health;
    public TextMeshProUGUI healthText;
    public float startHealth;
    private TextMeshProUGUI pointsText;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
    }

    public void OnTakeDamage(int damage)
    {
     
        health = health - damage;
        UpdateGui();
    }

    public void ResetHealth()
    {
            health = startHealth;
            UpdateGui();
    }

    public void AddHealth(int healthAdd)
    {
        health += healthAdd;
        UpdateGui();
    }
    public void AddPoints(int pointsForKill)
    {
        gameManager.pointsForKillEnemy += pointsForKill;
            UpdatePoints();
    }
    private void UpdateGui()
    {
        healthBar.fillAmount = health / startHealth;
        if (healthText)
        {
            healthText.text = health.ToString();
        }
    }

    private void UpdatePoints()
    {
        if (pointsText)
        {
            pointsText.text = gameManager.pointsForKillEnemy.ToString();
        }
    }
}
