using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    // Start is called before the first frame update
    #region PUBLIC VARIABLES
    public float rotationSpeed = 10f; // Rotation speed to rotate a ship in degrees for secoond
    public float movementSpeed = 1f; //The movement of ship by Force applied in units for second.
    #endregion

    #region PRIVATE VARIABLES
    private bool isRotating = false;
    private const string TURN_COROUTINE_FUNCTION = "TurnRotateAndMoveTowardsTap";
    #endregion

    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() //when the gameobject is active, then we are subscribing to the event
    {
        MyMobileGalaxyShooter.UserInputHandlerScript.OnTouchAction += TowardsTouch;
    }
    private void OnDisable() //when the gameobject is inactive, then we are desubscribing the event.
    {
        MyMobileGalaxyShooter.UserInputHandlerScript.OnTouchAction-= TowardsTouch;

    }
    #endregion

    #region MY PUBLIC METHODS
    public void TowardsTouch(Touch touch)
    {
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position); //It  converts screen pixel resolution to the word coordinates.
        StopCoroutine(TURN_COROUTINE_FUNCTION);
        StartCoroutine(TURN_COROUTINE_FUNCTION,touchWorldPosition); 
    }
    IEnumerator TurnRotateAndMoveTowardsTap(Vector3 tempPoint)
    {
        isRotating = true;
        tempPoint = tempPoint-this.transform.position; // To find the differences between touch position and current ship position
        tempPoint.z = transform.position.z; // assgining z value ship position to my touch position
        transform.position = tempPoint;
        Quaternion startrotation = this.transform.rotation; //start rotation, the rotataion start point.
        Quaternion endrotation = Quaternion.LookRotation(tempPoint, Vector3.up); //This rotation will look at touch point in a upward direction
        //---------------------------------------Need to rework on it!!------------------------------------------------------------------------
        float time = Quaternion.Angle(startrotation,endrotation)/rotationSpeed; //Angle between two rotations
        for (float i = 0; i < time; i= i+Time.deltaTime)
        {

            transform.rotation = Quaternion.Slerp(startrotation, endrotation, i);
            
        }
        transform.rotation = endrotation; //At this point, we need to put a shooting functionality here!
        isRotating=false;
        yield return (null);
    }
    #endregion





}