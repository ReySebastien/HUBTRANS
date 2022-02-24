using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScene : MonoBehaviour
{
    [SerializeField] private int scene;

    public int GetScene()
    {
        return scene;
    }
}
