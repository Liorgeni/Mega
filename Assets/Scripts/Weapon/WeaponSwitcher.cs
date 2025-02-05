using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }


    void Update()
    {
        int prevWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (prevWeapon != currentWeapon)
        {
            SetWeaponActive();
        }


    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }

    }


    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <=  0)
            {
                currentWeapon = transform.childCount -1;
            }
            else
            {
                currentWeapon--;
            }
        }

    }

    private void SetWeaponActive()
    {
        int weaponIdx = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIdx == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIdx++;
        }

    }

}
