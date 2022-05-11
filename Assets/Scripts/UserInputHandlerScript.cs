using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyMobileGalaxyShooter
{
    
    public class UserInputHandlerScript : MonoBehaviour
    {

        #region EVENTMETHODS
        public delegate void TapAction(Touch touch);
        public static event TapAction OnTouchAction;
        #endregion



        // Start is called before the first frame update
        #region PUBLIC VARIABLES
        public float tapMaxMovement = 50; //Maximum pixel tap can move
        #endregion

        #region PRIVATE VARAIBLES
        private Vector2 movement;           //Movement vector will track who far you move.

        private bool tapGestureFailed = false;  //tap Gesture will become,
        #endregion

        #region MONOBEHAVIOUR METHODS
        #endregion
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        { 
            if(Input.touchCount > 0) //To finding out,no.of touches greater than 0 or not. If no touches, then no movement.
            {
               Touch touch = Input.touches[0]; //Need to find out, number of touches on screen. If there are more no.oc touches, need to call array.
                if(touch.phase == TouchPhase.Began) // We have several touch phases, began enters the first frame of the touch.
                {
                    movement = Vector2.zero; //We made our movement to zero.

                }
               else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    movement += touch.deltaPosition; //The position delta since last change in pixel coordinates.
                    if (movement.magnitude > tapMaxMovement) //Bigger movements, its failed
                    {
                        tapGestureFailed = true;
                    }
                }
                
                else  // if finger is removed from screen, then we are calling if tapgesture is not failed.
                {
                    if(!tapGestureFailed)
                    {
                        if (OnTouchAction != null)
                        {
                            OnTouchAction(touch);
                        }
                    }
                   
                    tapGestureFailed = false; //Making ready for the next tap.
                }
                

            }



        }
        #region MY PUBLIC METHODS
        #endregion

    }
}
