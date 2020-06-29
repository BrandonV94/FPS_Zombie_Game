using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas PlayerDamageCanvas = null;
    [SerializeField] float impactTime = 1f;
  
    void Start()
    {
        PlayerDamageCanvas.enabled = false;
    }

    public void DisplayDamgeCanvas()
    {
        StartCoroutine(ToggleDamageCanvas());
    }

    IEnumerator ToggleDamageCanvas()
    {
        PlayerDamageCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        PlayerDamageCanvas.enabled = false;
    }
}
