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
    public UltimateCircularHealthBar foodBar, waterBar;
    public float totalFood, totalWater;

    // Start is called before the first frame update
    void Start()
    {
        totalFood = player.food;
        totalWater = player.water;
        foodBar.SetSegmentCount(10);
        waterBar.SetSegmentCount(10);
        //foodBar.SetRemovedSegments(0);
        //waterBar.SetRemovedSegments(0);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ReduceFoodWater", 5.0f);
    }
    void ReduceFoodWater()
    {
        player.food = player.food - 10;
        player.water = player.water - 10;
        foodBar.SetSegmentCount(10);
        waterBar.SetSegmentCount(10);
        foodBar.SetRemovedSegments(10 - (player.food / 10));
        waterBar.SetRemovedSegments(10 - (player.water / 10));
    }
}
