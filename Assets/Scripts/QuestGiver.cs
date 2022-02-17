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
    // retrieve quest object
    public Quest GetQuestInfo()
    {
        return quest[currentQuest];
    }
    public string GetStepInfo()
    {
        return quest[currentQuest].step[quest[currentQuest].currentStep];
    }
    public void CompleteQuest()
    {
        quest[currentQuest].isCompleted = true;
        quest[currentQuest].isActive = false;

        if (currentQuest < quest.Length - 1)
        {
            currentQuest++;
            quest[currentQuest].isActive = true;
        }
    }
    public void CompleteStep()
    {
        if (quest[currentQuest].currentStep >= quest[currentQuest].step.Length - 1)
        {
            // all steps completed
            CompleteQuest();
        }
        else
        {
            // continue to next step
            quest[currentQuest].currentStep++;
        }
    }
    public string GetCurrentQuest()
    {
        return quest[currentQuest].currentStep.ToString();
    }
    public void ForceQuestState(int q, int s)
    {
        currentQuest = q;
        quest[currentQuest].currentStep = s;
    }
}
