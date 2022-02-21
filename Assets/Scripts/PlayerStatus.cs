using RengeGames.HealthBars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerStatus : MonoBehaviour
{
    public Player player;
    public QuestGiver questGiver;
    public UltimateCircularHealthBar foodBar, waterBar, foodLegend, waterLegend;
    public TextMesh questTitle;
    public TextMesh questInfo;
    public TextMeshProUGUI mText;
    public Animator subAnimator;
    public AudioSource audioData;

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
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        else
        {
            if (audioData.isPlaying)
            {
                audioData.Stop();
            }
        }

        if (player.food <= 0 || player.water <= 0)
        {
            if (subAnimator != null)
            {
                mText.text = "You ran out of food or water. Make sure you keep tab of your food and water.";
                subAnimator.Play("subtitle", 1, 3f);
                subAnimator.Play("Subtitles", 1, 3f);
                Invoke("InitDeath", 3);
            }
        }
    }
    void ReduceFoodWater()
    {
        player.food = player.food - 0.1f;
        player.water = player.water - 0.1f;
    }
    void InitDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
