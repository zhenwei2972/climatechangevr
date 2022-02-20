using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class WaypointTrigger : MonoBehaviour
{
    public QuestGiver questGiver;
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
        if (collider.name == "Mouth" && this.gameObject.name == questGiver.GetCurrentQuest())
        {
            questGiver.CompleteStep();
            Destroy(this.gameObject);
        }
        if (collider.name == "Arc" && this.gameObject.name == questGiver.GetCurrentQuest())
        {
            questGiver.CompleteStep();
            Destroy(this.gameObject);
            SceneManager.LoadScene("NewLevel1");
        }
    }
}
