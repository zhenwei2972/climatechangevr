using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{
    public Quest[] quest;
    public int currentQuest = 0;
    public Player player;

    // initiate quest, set isActive to true
    public void StartQuest()
    {
        quest[currentQuest].isActive = true;
    }
    public void EndQuest()
    {
        quest[currentQuest].isActive = false;
    }
    // retrieve quest object
    public Quest GetQuestInfo()
    {
        return quest[currentQuest];
    }
    public void NextQuest()
    {
        currentQuest++;
    }
}
