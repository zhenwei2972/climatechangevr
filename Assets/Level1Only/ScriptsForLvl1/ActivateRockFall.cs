using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRockFall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rocks;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            rocks.SetActive(true);
        }
    }
}
