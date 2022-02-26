using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskComplete : MonoBehaviour
{
    public GameObject ArcEngine;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(ArcEngine))
        {
            Debug.Log("Game End");
            SceneManager.LoadScene("FinalSceneEndGame");
        }
    }
}
