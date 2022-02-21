using RengeGames.HealthBars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[System.Serializable]
public class PlayerStatus : MonoBehaviour
{
    public Player player;
    public QuestGiver questGiver;
    public UltimateCircularHealthBar foodBar, waterBar, foodLegend, waterLegend;
    public TextMesh questTitle;
    public TextMesh questInfo;
    //public TextMeshProUGUI mText;

    // Start is called before the first frame update
    void Start()
    {
        foodBar.SetSegmentCount(1);
        waterBar.SetSegmentCount(1);
        foodBar.SetPercent(player.food);
        waterBar.SetPercent(player.water);
        foodLegend.SetSegmentCount(1);
        foodLegend.SetPercent(0.99f);
        waterLegend.SetSegmentCount(1);
        waterLegend.SetPercent(0.99f);

        InvokeRepeating("ReduceFoodWater", 15.0f, 15.0f);
    }
    // Update is called once per frame
    void Update()
    {
        foodBar.SetPercent(player.food);
        waterBar.SetPercent(player.water);

        questTitle.text = questGiver.GetQuestInfo().title;
        questInfo.text = questGiver.GetStepInfo();

        if (player.food <= 0.2f || player.water <= 0.2f)
        {
            // play music
            InvokeRepeating("AlertFoodWater", 2.5f, 2.5f);
        }
        else
        {
            CancelInvoke("AlertFoodWater");
        }

        if (player.food <= 0 || player.water <= 0)
        {
            //mText.text = "You ran out of food or water and died. Make sure you keep track of your food and water levels.";
            //subAnimator.Play("subtitle", -1, 0f);
            //subAnimator.Play("Subtitles", -1, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void ReduceFoodWater()
    {
        player.food = player.food - 0.1f;
        player.water = player.water - 0.1f;
    }
    void AlertFoodWater()
    {
        //audioData.Play(0);
    }
}
