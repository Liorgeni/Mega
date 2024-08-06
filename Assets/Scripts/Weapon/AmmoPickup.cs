using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Ammo collected!");
            Destroy(gameObject);
               //GetComponent<Ammo>().IncreaseAmmo(ammoType, ammoAmount);

           FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
        }
    }

}
