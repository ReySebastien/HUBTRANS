using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    [SerializeField] private float boostForce;

    //when collide with player, make him jump and switch MovementType
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().SetJumpSpeed(boostForce);
            other.GetComponent<PlayerMovement>().SwitchMovementType(PlayerMovement.MovementType.TransitionFly);
        }
    }
}
