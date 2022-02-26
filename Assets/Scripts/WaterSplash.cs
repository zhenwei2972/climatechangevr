using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public GameObject Chair1, Chair2, Rock;
    public ParticleSystem waterSplash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(Chair1) || other.gameObject.Equals(Chair2) || other.gameObject.Equals(Rock))
        {
            waterSplash.Play();
        }
    }

}
