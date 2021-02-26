using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    public float ObjectAvoidanceDistance;
    float rayCastOffset = 2.5f;
    float detectionDistance = 5f;
    Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Turn()
    {
        var pos = PlayerPos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPos = GameObject.Find("Player").transform.position;

        //Turn();
        
         //Move();
        Rotate();
        path();
        
        var EnemyPos = transform.position;

        var XDistance = PlayerPos.x - EnemyPos.x;
        var YDistance = PlayerPos.y - (EnemyPos.y+1f);
        var ZDistance = PlayerPos.z - (EnemyPos.z+0.5f);

        var DirectDistance = Mathf.Sqrt((XDistance * XDistance) + (YDistance * YDistance) + (ZDistance * ZDistance));
        //Debug.Log(DirectDistance);
        if(DirectDistance < 1.5)
        {
            SceneManager.LoadScene("Main");
        }


        //Debug.Log(DirectDistance);

    }

    void Rotate()
    {
        Vector3 positionDif = PlayerPos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(positionDif);
        transform.rotation = Quaternion.LookRotation(positionDif);                                                  //TAKE THIS OUT
    }


    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;


    }

    void path()
    {
        var ycoord = transform.position.y;
        var xcoord = transform.position.x;
        var zcoord = transform.position.z;
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(xcoord,ycoord-1,zcoord), PlayerPos, out hit, 2f))
        {
            //var Ymove = (1f*Time.deltaTime);
            transform.Translate(0, Speed*Time.deltaTime, 0);
            Debug.DrawRay(transform.position-transform.up, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
        else
        {
            Move();
        }

    }
}
