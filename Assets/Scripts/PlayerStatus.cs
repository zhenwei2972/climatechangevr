﻿using RengeGames.HealthBars;
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
    public TextMesh questTitle;
    public TextMesh questInfo;

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
        player.food = player.food - 0.1f;
        player.water = player.water - 0.1f;
        foodBar.SetPercent(player.food);
        waterBar.SetPercent(player.water);
        foodBar.AddRemovePercent(0.1f);
        waterBar.AddRemovePercent(0.1f);
    }
}
