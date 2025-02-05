using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }


    public void HandleDeath()
    {

    gameOverCanvas.enabled = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    GetComponent<FirstPersonController>().enabled = false;
    FindObjectOfType<WeaponSwitcher>().enabled = false;
    Time.timeScale = 0f;


    }

}
