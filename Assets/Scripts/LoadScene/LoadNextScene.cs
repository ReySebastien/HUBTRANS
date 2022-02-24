using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private RawImage blackscreen;

    private async void Start()
    {
        var scene = SceneManager.LoadSceneAsync(S_LoadSceneData.nextScene);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);

        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
    }
}
