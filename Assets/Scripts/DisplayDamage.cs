using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas enemyImpact;
    [SerializeField] float impactTime = 0.3f;

    void Start()
    {
        enemyImpact.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());

    }

    IEnumerator ShowSplatter()

    {
        enemyImpact.enabled = true;
        yield return new WaitForSeconds(impactTime);
        enemyImpact.enabled = false;

    }

}
