using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class QuestManager : MonoBehaviour
{
    public QuestGiver quest;
    string questFile, initFile;
    private void Awake()
    {
        questFile = Application.persistentDataPath + "/questData.data";
        initFile = Application.dataPath + "/Scripts/questinit.json";
    }
    // Start is called before the first frame update
    // On init we look for a saved quest state
    // For first time startup we will create one that is default.
    void Start()
    {
        /*
        // load saved quest state if any
        if (File.Exists(questFile))
        {
            // File exists!
            string jsonFile = File.ReadAllText(questFile);
            JsonUtility.FromJsonOverwrite(jsonFile, quest);
        }
        else
        {
            // File does not exist.
            string jsonFile = File.ReadAllText(initFile);
            JsonUtility.FromJsonOverwrite(jsonFile, quest);
        }
        */

        // File does not exist.
        if (quest.currentQuest == 0)
        {
            string jsonFile = File.ReadAllText(initFile);
            JsonUtility.FromJsonOverwrite(jsonFile, quest);
        }
        else
        {
            int q = quest.currentQuest;
            string jsonFile = File.ReadAllText(initFile);
            JsonUtility.FromJsonOverwrite(jsonFile, quest);
            quest.ForceQuestState(q, 0);
            Debug.Log("Quest now: " + quest.currentQuest);
        }
        // quest.ForceQuestState(0, 0);
        //InvokeRepeating("TestUpdate", 5.0f, 5.0f);
    }
    // call whenever a checkpoint is reached or quest complete
    // this function saves the current status of the quest
    void SaveQuestState()
    {
        File.WriteAllText(questFile, JsonUtility.ToJson(quest));
    }
    // Call this to restart the whole queststate from scratch.
    void RestartQuestState()
    {
        string jsonFile = File.ReadAllText(initFile);
        JsonUtility.FromJsonOverwrite(jsonFile, quest);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Quest: " + quest.GetCurrentQuest());
    }
    void TestUpdate()
    {
        // test update for quests
        quest.CompleteStep();
    }

    public QuestGiver GetQuestGiver()
    {
        return quest;
    }
}
