using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collisionController : MonoBehaviour
{
    public PlayerGui helthbar;
    public GameManager gameManager;
    private GameObject DamageTextHolder;
    private TextMeshProUGUI DamageText;

    private int takeDamageAmount;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (this.gameObject.tag == "Enemy")
        {
            takeDamageAmount = gameManager.EnemyDamage;
            DamageTextHolder = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            DamageText = DamageTextHolder.GetComponent<TextMeshProUGUI>();
            DamageTextHolder.SetActive(false);
        }
        if (this.gameObject.tag == "Player")
        {
            takeDamageAmount = gameManager.PlayerDamage;
            helthbar = GameObject.Find("PlayerHealth").GetComponent<PlayerGui>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (helthbar)
            {
                helthbar.OnTakeDamage(takeDamageAmount);
                if (this.gameObject.tag == "Enemy")
                {
                    StartCoroutine(showDamage());

                    DamageText.text = gameManager.EnemyDamage.ToString();
                }
            }
            if (helthbar.health <= 0)
            {

                if (this.gameObject.tag == "Enemy")
                {
                    Debug.Log("PointsAdd");
                    helthbar.AddPoints(50);
                    gameManager.SetNewEnemy();
                    gameManager.SetNewEnemy();
                    Destroy(this.gameObject);
                }
                if (this.gameObject.tag == "Player")
                {
                    gameManager.SetNewPlayer();
                    helthbar.ResetHealth();
                }
            }
        }
    }

    IEnumerator showDamage()
    {
        DamageTextHolder.SetActive(true);
        yield return new WaitForSeconds(1);
        DamageTextHolder.SetActive(false);

    }


}
