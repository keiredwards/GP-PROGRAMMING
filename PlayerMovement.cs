using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    // Start is called before the first frame update
    public GameObject Player;
    public GameObject World;
    public int _rotationSpeed;
    public int _movementSpeed;
    float currentPosX = 1.5F;
    float currentPosY = 1.03F;
    float currentPosZ = -6.5F;
    public float JumpSpeed;
    public float Gravity;
    float VelocityX = 0;
    float VelocityY = 0;
    float VelocityZ = 0;
    float move =  0;
    bool forwardBlocked = false;
    bool backBlocked = false;
    int scale = 1;
    public float cooldownTimer;
    float cooldownLeft = 0;
    public int MaxJumps;
    int JumpsLeft;
    

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && cooldownLeft == 0 && JumpsLeft>0)
            {
            VelocityY = JumpSpeed;
            cooldownLeft = cooldownTimer;
            JumpsLeft -= 1;
            }
        else
        {
            if (cooldownLeft > 0)
            {
                cooldownLeft -= Time.deltaTime;
            }
            if (cooldownLeft < 0)
            {
                cooldownLeft = 0;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            World.transform.localScale = new Vector3(-scale, 1, 1);
            scale = -(scale);
        }


        float turn = (Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime);

        if (((forwardBlocked == true) && (Input.GetAxisRaw("Vertical") > 0))||((backBlocked==true) && ((Input.GetAxisRaw("Vertical") < 0)))) 
        {
                move = 0;
        }
        else
        {
            move = (Input.GetAxisRaw("Vertical") * _movementSpeed * Time.deltaTime);
        }

        Player.transform.Rotate(0.0f, turn, 0.0f, Space.World);
        Player.transform.Translate(0.0f, VelocityY, move);

        VelocityY = VelocityY - Time.deltaTime * (Gravity);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.25f))
        {
            
            //Debug.Log("Did Hit");

            forwardBlocked = true;
        }
        else
        {
            forwardBlocked = false;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);

        }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
            //Debug.Log("Did Hit");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))   
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 0.25f))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            backBlocked = true;
        }
        else
        {
            backBlocked = false;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 0.5f))
        {
           VelocityY = 0;
           VelocityY = VelocityY - Time.deltaTime * (Gravity);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.green);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f))  //half the body height plus a little gap to account for distance travelled in frame.
            {
                
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
                if (VelocityY <= 0)
            {
                VelocityY = 0;
                JumpsLeft = MaxJumps;  //When the player lands on a surface, they regain the jumps.
                Player.transform.Translate(0, (0.25f-hit.distance), 0.0f); //If the raycast is shorter than half of the body size, move the object up that distance. This takes the player outside of the floor.

            }
            //Debug.Log(hit.distance);
        }
    }
}