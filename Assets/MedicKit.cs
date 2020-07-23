using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicKit : MonoBehaviour
{
    public int medicKitPower;
    public float timeToDestroyMedicKit;

    private void Start()
    {
        Destroy(gameObject, timeToDestroyMedicKit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<collisionController>().helthbar.AddHealth(medicKitPower);
            Destroy(gameObject);
        }
    }
}
