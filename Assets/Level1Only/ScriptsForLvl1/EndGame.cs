using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smoke;
    public AudioSource gasSound;

    void Start()
    {
        StartCoroutine("Smoke");
    }

    // Update is called once per frame
    void Update()
    {
        //If Press A
        SceneManager.LoadScene("");
    }

    IEnumerator Smoke()
    {
        yield return new WaitForSeconds(8f);
        smoke.SetActive(true);
        gasSound.Play();
    }
}
