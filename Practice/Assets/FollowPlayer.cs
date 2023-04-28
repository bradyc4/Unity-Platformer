using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 direction;
    public Vector3 location;
    public float distance = 10f;
    float rotationX = 0f;
    float rotationY = 0f;
    float sinofXrot, cosofXrot, sinofYrot, cosofYrot;

    public float sensitivity = 4f;

    // Function to help make debugging a little easier
    void p(object s){
        Debug.Log(s);
    }

    void Update(){
        /* Two variables keep track of how the mouse moves frame by frame in 2 dimensions.
        Their values are then used as degrees for the camera's rotation. */
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        // These two if statements put a cap on looking up and down so that the camera doesn't go upside down.
        if(rotationX>90){
            rotationX = 90f;
        }
        if(rotationX<-90){
            rotationX = -90f;
        }

        sinofYrot = -1 * Mathf.Sin(Mathf.Deg2Rad * rotationY); // x distance while looking left and right
        cosofYrot = -1 * Mathf.Cos(Mathf.Deg2Rad * rotationY); // z distance while looking left and right
        sinofXrot = Mathf.Sin(Mathf.Deg2Rad * rotationX); // y distance while looking up and down
        cosofXrot = Mathf.Cos(Mathf.Deg2Rad * rotationX); // z distance while looking up and down (relative to rotation on Y axis; looking left and right)
        // p("sinofYrot = "+sinofYrot+",  cosofYrot = "+cosofYrot+",  sinofXrot = "+sinofXrot+",  cosofXrot = "+cosofXrot);
        direction = new Vector3(sinofYrot * cosofXrot, sinofXrot, cosofYrot * cosofXrot); //the direction of the camera offset, I multiply the x and the z values by cosofXrot so that the camera pulls closer when looking up or down
        location = (direction * distance) + new Vector3(0,2,0); // the offset of the camera, using the direction and multiplied by distance. I add 2 to the y value to have the camera sit a little high.
        transform.position = player.position + location; // position of the camera is the player's position plus the offset
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0); // rotates the camera to face the center of its orbit, which is the player
    }
}
