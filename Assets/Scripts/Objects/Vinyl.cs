using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vinyl : MonoBehaviour
{
    private Text vinylText;

    private SoundManager soundManager;

    private void Start()
    {
        vinylText = FindObjectOfType<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            soundManager.PlaySound();
            ScoreManager.AddVinyl(1);
            vinylText.text = "Vinyl : " + ScoreManager.vinylCount;
            Destroy(gameObject);
        }
    }

    public void SetSoundManager(SoundManager sceneSoundManager)
    {
        soundManager = sceneSoundManager;
    }
}
