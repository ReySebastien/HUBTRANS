using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;

    [SerializeField] private float beatBetweenObs, totalObsSpawned;

    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        for (int i = 0; i < totalObsSpawned; i++)
        {
            var position = new Vector3(transform.position.x + S_SongData.distancePerBeat * i * beatBetweenObs, transform.position.y, 0) + S_SongData.offset;
            var vinyl = Instantiate(prefabs, position, Quaternion.Euler(90, 90, 0), transform);
            vinyl.GetComponent<Vinyl>().SetSoundManager(soundManager);
        }
    }
}
