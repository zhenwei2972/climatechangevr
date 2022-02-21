using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Subtitles : MonoBehaviour
{
    public TextMeshProUGUI mText;
    public Animator subAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Mouth")
        {
            switch(this.name)
            {
                // scene 1 scripts
                case "sub1":
                    mText.text = "<size=%25>SODaLG</size>: Try to look at your watch from time to time. It will provide you with instructions and indicate how much food and water is left.";
                    break;
                case "sub2":
                    mText.text = "<size=%25>SODaLG</size>: This city is the last holdout of humanity, the dome protects us from the dangers of the outside world.";
                    break;
                case "sub3":
                    mText.text = "<size=%25>SODaLG</size>: We need a new power generator if we were to keep this city functional.";
                    break;
                case "sub4":
                    mText.text = "<size=%25>SODaLG</size>: Go out there and find us the new power generator.";
                    break;
                // scene 2 scripts
                case "sub5":
                    mText.text = "<size=%25>SODaLG</size>: The city used to be buzzing with life, now its but a empty husk.";
                    break;
                case "sub6":
                    mText.text = "<size=%25>SODaLG</size>: Look over there, maybe there's a way to clear those cars and get across.";
                    break;
                case "sub7":
                    mText.text = "<size=%25>SODaLG</size>: Those benches, maybe we can find a way to get rid of those benches blocking the road.";
                    break;
                case "sub8":
                    mText.text = "<size=%25>SODaLG</size>: The submarine, maybe it has a working generator that we can use. Find a way to it.";
                    break;
                case "sub9":
                    mText.text = "<size=%25>SODaLG</size>: The gate...it looks like it can be broken.";
                    break;
                case "sub10":
                    mText.text = "<size=%25>SODaLG</size>: It's a maze in here. Get into the submarine before you run out of food and water!";
                    break;
                case "sub11":
                    mText.text = "<size=%25>SODaLG</size>: The submarine! Head towards it and get inside.";
                    break;
                // scene 3 scripts
                case "sub12":
                    mText.text = "<size=%25>SODaLG</size>: Find the generator it is probably around the corner.";
                    break;
                case "sub13":
                    mText.text = "<size=%25>SODaLG</size>: There it is. Shrink it and bring it back to the entrance.";
                    break;
                // extra
                case "sub14":
                    mText.text = "<size=%25>SODaLG</size>: On your journey you may find obstacles blocking your path. The shrinking gun may prove to be helpful to you.";
                    break;
                default:
                    mText.text = "";
                    break;
            }
            subAnimator.Play("subtitle", - 1, 0f);
            subAnimator.Play("Subtitles", - 1, 0f);
            Destroy(this.gameObject);
        } // end of trigger
    }
}
