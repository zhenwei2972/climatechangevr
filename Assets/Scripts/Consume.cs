using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Consume : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "food")
        {
            player.food = player.food + 0.2f;
            Destroy(collider.gameObject);
        }
        else if (collider.tag == "water")
        {
            player.water = player.water + 0.2f;
            Destroy(collider.gameObject);
        }
    }
}
