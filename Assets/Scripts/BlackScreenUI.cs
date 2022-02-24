
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActive(bool newActive)
    {
        gameObject.SetActive(true);
        Debug.Log("BlackScreen");
    }
}
