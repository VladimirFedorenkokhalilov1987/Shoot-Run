using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private float speed = 100f;

        public void DoShoot()
        {
            GameObject newBullet =
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.rotation) as GameObject;
            Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
            newBulletRigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
