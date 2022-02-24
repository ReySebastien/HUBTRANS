using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerMovement playerMovementScript;

    private void Start()
    {
        playerMovementScript = player.GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if(playerMovementScript.GetMovementType() == PlayerMovement.MovementType.MapGround)
        {
            PlayerXPosition();
        }

        else if (playerMovementScript.GetMovementType() == PlayerMovement.MovementType.TransitionFly)
        {
            PlayerXPosition();
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        }

        else if (playerMovementScript.GetMovementType() == PlayerMovement.MovementType.TransitionGround)
        {
            PlayerXPosition();
            PlayerYPosition();
        }

        else if (playerMovementScript.GetMovementType() == PlayerMovement.MovementType.MapFly)
        {
            PlayerXPosition();
            transform.Translate(0, CustomGravity.customGravity * Time.deltaTime, 0);
        }
    }

    private void PlayerXPosition()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
    }

    private void PlayerYPosition()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, 0);
    }

}
