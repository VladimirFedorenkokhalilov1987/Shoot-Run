using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private collisionController [] Players;
    public int EnemyDamage;
    public int PlayerDamage;
    
    public int TotalPlayersCount = 0;
    public GameObject Enemy;
    public GameObject Medickit;
    public GameObject PlayerSpawn;
    public GameObject [] enemySpawns;
    
    public float pointsForKillEnemy = 0;


    public float timeToMedicKit;
    private float timeToMedicKitDefault;

    private void Start()
    {
        timeToMedicKitDefault = timeToMedicKit;
    }

    public void GetAllPlayers()
    {
        Players = FindObjectsOfType<collisionController>();
        TotalPlayersCount = Players.Length;
        if (TotalPlayersCount > 11)
        {
            GameObject destroyPlayer = FindObjectOfType<collisionController>().gameObject;
            if (destroyPlayer.gameObject.tag == "Enemy")
            {
                Destroy(destroyPlayer);
            }

        }
    }

    public void SetNewEnemy()
    {

        GameObject newEnemy =
            Instantiate(Enemy, enemySpawns[Random.Range(0,enemySpawns.Length)].transform.position, Quaternion.identity) as GameObject;
        newEnemy.name = "NewEnemy";
    }
    public void SetNewPlayer()
    {
        GameObject newPlayer = FindObjectOfType<Player>().gameObject;
        newPlayer.transform.position = PlayerSpawn.transform.position;
    }
    public void SetNewMedickit()
    {
        GameObject newPMedicKit =
            Instantiate(Medickit, enemySpawns[Random.Range(0,enemySpawns.Length)].transform.position, Quaternion.identity) as GameObject;
        newPMedicKit.name = "NewMedicKit";
    }
    private void Update()
    {
        timeToMedicKit -= Time.deltaTime;
        if (timeToMedicKit <= 0)
        {
            SetNewMedickit();
            SetNewMedickit();

            timeToMedicKit = timeToMedicKitDefault;
        }

        GetAllPlayers();
    }
}
