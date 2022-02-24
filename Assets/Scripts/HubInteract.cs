using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubInteract : MonoBehaviour
{
    [SerializeField] private ButtonLoadScene loadScene;

    void Update()
    {
            if (Input.GetMouseButtonUp(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {

                //Replace this with whatever logic you want to use to validate the objects you want to click on
                if (hit.collider.gameObject.tag == "interactif")
                {
                    var nextScene = hit.collider.gameObject.GetComponent<ObjectScene>().GetScene();
                    loadScene.LoadSceneWithIndex(nextScene);
                }
            }
        }
    }
}
