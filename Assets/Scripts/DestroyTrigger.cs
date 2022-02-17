using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DestroyTrigger : MonoBehaviour
{
    public GameObject target;
    public QuestGiver questGiver;
    private bool multiTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        // check if target has multiple children target
        if (target.transform.childCount > 0)
        {
            multiTarget = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for multiple targets, if all targets eliminated
        if (target.transform.childCount <= 0 && multiTarget)
        {
            if (this.gameObject.name == questGiver.GetCurrentQuest())
            {
                questGiver.CompleteStep();
            }
        }
        // for single target. Not needed yet
    }
}
