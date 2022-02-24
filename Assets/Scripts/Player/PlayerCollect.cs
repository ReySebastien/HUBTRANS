using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    [SerializeField] private int vinylCount;
    [SerializeField] private PlayerMovement myMovement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vinyl")
        {
            vinylCount+=1;
            VerifyVinylNumber();
        }
    }

    private void VerifyVinylNumber()
    {
        if(vinylCount >= 16)
        {
            vinylCount = 0;
            myMovement.SwitchMovementType(PlayerMovement.MovementType.TransitionFly);
            myMovement.SetJumpSpeed(50);
        }
    }
}
