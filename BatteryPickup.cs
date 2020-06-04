using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreSpotAngle= 70f;
    [SerializeField] float restoreLightIntensity = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colliding with battery.");
            other.GetComponentInChildren<FlashLight>().RestoreLightAngle(restoreSpotAngle);
            other.GetComponentInChildren<FlashLight>().RestoreLightIntensity(restoreLightIntensity);
            Destroy(gameObject);
        }
    }
}
