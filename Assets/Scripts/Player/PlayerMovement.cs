using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementType { Hub, MapGround, MapFly, TransitionFly, TransitionGround }

    [SerializeField] private MovementType movementType;

    [SerializeField] private float groundSpeed, speed, jumpSpeed, boostForce;

    private int direction;

    [SerializeField]
    private Transform raycastUpDown;

    [SerializeField]
    private Transform raycastLeftRight;

    [SerializeField]
    private float raycastDistance;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField] private SpawnFlyPattern flyPatternManager;


    //Use the correct Movement Fonction
    void Update()
    {
        switch (movementType)
        {
            case MovementType.Hub:
                HubMovement();
                break;

            case MovementType.MapGround:
                SetSpawnFlyPattern(false);
                MapGroundMovement();
                break;

            case MovementType.TransitionFly:
                TransitionFly();
                break;

            case MovementType.MapFly:
                SetSpawnFlyPattern(true);
                MapFlyMovement();
                break;

            case MovementType.TransitionGround:
                TransitionGround();
                break;

            default:
                print("Type de deplacement inconnu !");
                break;
        }

    }

    public void SwitchMovementType(MovementType newMovementType)
    {
        movementType = newMovementType;
    }

    // Debug Tool to switch when needed
    public void SwitchButton()
    {
        if (movementType == MovementType.MapFly)
        {
            movementType = MovementType.TransitionGround;
        }

        else
        {
            movementType = MovementType.TransitionFly;
            SetJumpSpeed(50);
        }
    }

    //Need to change to a camera system
    private void HubMovement()
    {
        transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime);

    }

    //Movement on the Ground
    private void MapGroundMovement()
    {
        //RayCast to know if there is a invi wall
        raycastLeftRight.localPosition = Vector3.forward * Mathf.Sign(Input.GetAxis("Horizontal")) * -1;

        if (!(Physics.Raycast(raycastLeftRight.position, Vector3.forward * Input.GetAxis("Horizontal") * -1, raycastDistance, layerMask)))
        {
            //Left/Right Movement
            transform.Translate(0, 0, Input.GetAxis("Horizontal") * -1 * groundSpeed * Time.deltaTime);
        }

        ForwardMovement();

    }

    //Movement when switching from Ground to Fly
    private void TransitionFly()
    {
        ForwardMovement();
        transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
        jumpSpeed += CustomGravity.customGravity * 10 * Time.deltaTime;

        if (jumpSpeed < 10)
        {
            jumpSpeed = 0;
            SwitchMovementType(MovementType.MapFly);
        }
    }

    //Movement when Flying
    private void MapFlyMovement()
    {
        raycastUpDown.localPosition = Vector3.up * Mathf.Sign(Input.GetAxis("Vertical"));
        raycastLeftRight.localPosition = Vector3.forward * Mathf.Sign(Input.GetAxis("Horizontal")) * -1;

        transform.Translate(0, CustomGravity.customGravity * Time.deltaTime, 0);

        if (!(Physics.Raycast(raycastUpDown.position, Vector3.up * Input.GetAxis("Vertical"), raycastDistance)))
        {
            //Up/Down Movement
            transform.Translate(0, Input.GetAxis("VerticalFly") * speed * Time.deltaTime, 0);

        }

        if (!(Physics.Raycast(raycastLeftRight.position, Vector3.forward * Input.GetAxis("Horizontal") * -1, raycastDistance)))
        {
            //Left/Right Movement
            transform.Translate(0, 0, Input.GetAxis("HorizontalFly") * speed * Time.deltaTime * -1);
        }

        ForwardMovement();

        if (transform.position.y <= 8)
        {
            SwitchMovementType(MovementType.TransitionGround);
        }
    }

    //Movement when switching from Flying to Ground
    private void TransitionGround()
    {
        ForwardMovement();

        transform.Translate(0, CustomGravity.customGravity * 8 * Time.deltaTime, 0);
        if (transform.position.y <= 0.1)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            SwitchMovementType(MovementType.MapGround);
        }
    }

    //Constant Forward Movement
    private void ForwardMovement()
    {
        transform.Translate(1 / (60 / S_SongData.bpm) * S_SongData.distancePerBeat * Time.deltaTime, 0, 0);
    }

    public void SetJumpSpeed(float newJumpSpeed)
    {
        jumpSpeed = newJumpSpeed;
    }

    public MovementType GetMovementType()
    {
        return movementType;
    }

    private void SetSpawnFlyPattern(bool newValue)
    {
        flyPatternManager.SetSpawnFlyPattern(newValue);
    }

}