using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Player player;
    public Text foodText;
    public Text waterText;
    private int food;
    private int water;
    public QuestGiver questGiver;

    // Start is called before the first frame update
    void Start()
    {
        food = player.food;
        water = player.water;
        foodText.text = "Food: " + player.food;
        waterText.text = "Water: " + player.water;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.food = food--;
            player.water = water--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.food = food++;
            player.water = water++;
        }

        foodText.text = "Food: " + food;
        waterText.text = "Water: " + water;
    }
}
