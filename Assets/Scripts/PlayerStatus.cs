using RengeGames.HealthBars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStatus : MonoBehaviour
{
    public Player player;
    public QuestGiver questGiver;
    public UltimateCircularHealthBar foodBar, waterBar, foodLegend, waterLegend;
    public float totalFood, totalWater;
    public TextMesh questTitle;
    public TextMesh questInfo;

    // Start is called before the first frame update
    void Start()
    {
        //questTitle = GameObject.Find("Quest Title").GetComponent<TextMesh>();
        //questInfo = GameObject.Find("Quest Info").GetComponent<TextMesh>();
        totalFood = player.food;
        totalWater = player.water;
        foodBar.SetSegmentCount(1);
        waterBar.SetSegmentCount(1);
        foodBar.SetPercent(0.99f);
        waterBar.SetPercent(0.99f);
        foodLegend.SetSegmentCount(1);
        foodLegend.SetPercent(0.99f);
        waterLegend.SetSegmentCount(1);
        waterLegend.SetPercent(0.99f);

        InvokeRepeating("ReduceFoodWater", 5.0f, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        questTitle.text = questGiver.GetQuestInfo().title;
        questInfo.text = questGiver.GetQuestInfo().description;
    }
    void ReduceFoodWater()
    {
        player.food = player.food - 10;
        player.water = player.water - 10;
        foodBar.AddRemovePercent(0.1f);
        waterBar.AddRemovePercent(0.1f);
    }
}
