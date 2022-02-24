using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ButtonLoadScene : MonoBehaviour
{
    public void LoadSceneWithIndex(int sceneIndex)
    {
        S_LoadSceneData.nextScene = sceneIndex;
        var scene = SceneManager.LoadSceneAsync(S_LoadSceneData.loadSceneIndex);

    }
}
