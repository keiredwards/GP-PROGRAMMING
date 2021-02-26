using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
         Speed = Random.Range(1, 2f);
    }

    void Move()
    {
        transform.parent.position += transform.parent.forward * Time.deltaTime * Speed;


    }

    void Rotate()
    {
                                                         //TAKE THIS OUT
    }

    void OnTriggerStay(Collider other)
    {
        Vector3 otherposition = other.transform.position;
        Vector3 position = transform.parent.position;
        Vector3 positionDif = -(otherposition - position)*Random.Range(5f,10f);
        Vector3 positionDifnoY = new Vector3(positionDif.x, 0f, positionDif.z);
        transform.parent.rotation = Quaternion.LookRotation(positionDifnoY);
    }



    // Update is called once per frame
    void Update()
    {
        Move();
        }
    }

