/*using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Rigidbody rb;
    public float forceIntensity = 1000f;
    public FollowPlayer fp;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w")){
            rb.AddForce(fp.forwardV * forceIntensity * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            rb.AddForce(fp.leftV * forceIntensity * Time.deltaTime);
        }
        if(Input.GetKey("s")){
            rb.AddForce(fp.backwardV * forceIntensity * Time.deltaTime);
        }
        if(Input.GetKey("d")){
            rb.AddForce(fp.rightV * forceIntensity * Time.deltaTime);
        }
    }
}*/