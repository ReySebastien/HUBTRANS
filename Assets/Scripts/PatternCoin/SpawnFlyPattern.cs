using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyPattern : MonoBehaviour
{

    private bool spawnPattern = false;
    [SerializeField] private float beatsBetweenObject, distanceWithPlayer, heightOffset;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject prefabs;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject parent;

    private void Start()
    {
        StartCoroutine("SpawnFlyPatterns");
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + distanceWithPlayer, player.transform.position.y, 0);
    }

    IEnumerator SpawnFlyPatterns()
    {

        while (spawnPattern)
        {
            yield return new WaitForSeconds(60 / S_SongData.bpm * 4);

            var randomPattern = Random.Range(0, 4);

            switch (randomPattern)
            {
                case 0:
                    Pattern1();
                    break;

            }

            SetSpawnFlyPattern(false);


        } 

        

    }

    private void SpawnThePattern(Vector3[] position, int coins)
    {
        //var numberOfCoins = coins;
        //var coinsZPosition = xPosition;


        for (int i = 0; i < coins; i++)
        {
            var finalPosition = new Vector3(transform.position.x + distanceWithPlayer + S_SongData.distancePerBeat * beatsBetweenObject, position[i].y + transform.position.y, position[i].z) + S_SongData.offset;
            var vinyl = Instantiate(prefabs, finalPosition, Quaternion.Euler(90, 90, 0), parent.transform);
            vinyl.GetComponent<Vinyl>().SetSoundManager(soundManager);
        }
    }

    private void Pattern1()
    {
        var numberOfCoins = 2;
        var coinsPosition = new Vector3[] { new Vector3(0, 0, 0) , new Vector3(0, 0, 1) };

        SpawnThePattern(coinsPosition, numberOfCoins);
    }

    public void SetSpawnFlyPattern(bool newSpawnPattern)
    {
        spawnPattern = newSpawnPattern;
        VerifyCoroutine(newSpawnPattern);
    }

    private void VerifyCoroutine(bool value)
    {
        if (value)
        {
            StartCoroutine("SpawnFlyPatterns");
        }
    }
}
