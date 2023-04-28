/*using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 direction;
    public Vector3 location;
    public Vector3 forwardV;
    public Vector3 backwardV;
    public Vector3 leftV;
    public Vector3 rightV;
    public float distance = 10f;
    float rotationX = 0f;
    float rotationY = 0f;
    float forward, backward, left, right, sinofXrot, cosofXrot, sinofYrot, cosofYrot;

    public float sensitivity = 4f;

    // Update is called once per frame
    void Update(){
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        forward = rotationY;
        backward = rotationY + 180;
        left = rotationY - 90;
        right = rotationY + 90;
        if(rotationX>90){
            rotationX = 90f;
        }
        if(rotationX<-90){
            rotationX = -90f;
        }
        sinofYrot = -1 * Mathf.Sin(Mathf.Deg2Rad * rotationY); //x distance while looking left and right
        cosofYrot = -1 * Mathf.Cos(Mathf.Deg2Rad * rotationY); //z distance while looking left and right
        sinofXrot = Mathf.Sin(Mathf.Deg2Rad * rotationX); //y distance while looking up and down
        cosofXrot = Mathf.Cos(Mathf.Deg2Rad * rotationX); //z distance while looking up and down
        direction = new Vector3(sinofYrot * cosofXrot, sinofXrot, cosofXrot * cosofYrot);
        forwardV = new Vector3(Mathf.Sin(Mathf.Deg2Rad * forward), 0, Mathf.Cos(Mathf.Deg2Rad * forward));
        backwardV = forwardV*-1;
        rightV = new Vector3(Mathf.Sin(Mathf.Deg2Rad * right), 0, Mathf.Cos(Mathf.Deg2Rad * right));
        leftV = rightV*-1;
        location = (direction * distance) + new Vector3(0,2,0);
        transform.position = player.position + location;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}*/
