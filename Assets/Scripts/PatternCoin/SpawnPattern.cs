using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject prefabsCoins;
    [SerializeField] private float beatsBetweenObject;
    [SerializeField] private int totalObjectSpawned, MinBetweenPattern, MaxBetweenPattern;

    private float xDistance; //Distance to spawn the first coin of the pattern

    private void Start()
    {
        var nextPattern = 0f; //Next pattern spawn on that beat

        //For every 
        for (int i = 0; i < totalObjectSpawned; i += 4)
        {

            if (nextPattern == i)
            {
                xDistance = i;
                RandomPatternSpawn();
                var randomBeat = Random.Range(MinBetweenPattern ,MaxBetweenPattern+1);
                nextPattern = i + randomBeat * (4/ beatsBetweenObject);
            }
        }
    }

    //Pick a Random coin Pattern to spawn
    private void RandomPatternSpawn()
    {
        var randomNumber = Random.Range(0, 2); //Random pattern picked

        switch (randomNumber)
        {
            case 0:
                Pattern1();
                break;

            case 1:
                Pattern2();
                break;

            case 2:
                Pattern3();
                break;
        }


    }

    //Spawn a pattern
    private void SpawnThePattern(float[] xPosition, int coins)
    {
        var numberOfCoins = coins;
        var coinsZPosition = xPosition;


        for (int i = 0; i < numberOfCoins; i++)
        {
            var position = new Vector3(transform.position.x + S_SongData.distancePerBeat * (xDistance + i) * beatsBetweenObject, transform.position.y, coinsZPosition[i]) + S_SongData.offset;
            var vinyl = Instantiate(prefabsCoins, position, Quaternion.Euler(90, 90, 0), transform);
            vinyl.GetComponent<Vinyl>().SetSoundManager(soundManager);
        }
    }

    private void Pattern1()
    {
        var numberOfCoins = 8;
        var coinsZPosition = new float[] { 0, 1, 2, 3, 4, 5, 6, 7 };

        SpawnThePattern(coinsZPosition, numberOfCoins);

    }

    

    private void Pattern2()
    {
        var numberOfCoins = 16;
        var coinsZPosition = new float[] { 0, -1, -2, -3, -4, -5, -6, -7, -7, -6, -5, -4, -3, -2, -1, 0 };

        SpawnThePattern(coinsZPosition, numberOfCoins);
    }

    private void Pattern3()
    {
        var numberOfCoins = 8;
        var coinsZPosition = new float[] { 0, -1, -2, -3, -4, -5, -6, -7 };

        SpawnThePattern(coinsZPosition, numberOfCoins);
    }

}
