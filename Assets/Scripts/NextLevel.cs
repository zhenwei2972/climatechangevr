using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider) // can be Collider HardDick if you want.. I'm not judging you
    {
        if (collider.name == "Mouth" && this.name == "toScene2")
        {
            SceneManager.LoadScene("Level2_Prototype");
        }
        if (collider.name == "Mouth" && this.name == "toScene3")
        {
            SceneManager.LoadScene("Level2_Sub");
        }
    }

}
