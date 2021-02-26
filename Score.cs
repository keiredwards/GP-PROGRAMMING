using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            if (hit.distance < 0.2)
            {
                Player.Score += 1;
                Destroy(coin);
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            if (hit.distance < 0.2)
            {
                Player.Score += 1;
                Destroy(coin);
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            if (hit.distance < 0.2)
            {
                Player.Score += 1;
                Destroy(coin);
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            if (hit.distance < 0.2)
            {
                Player.Score += 1;
                Destroy(coin);
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))         //just so i can see which way is forward
        {
            if (hit.distance < 0.2)
            {
                Player.Score += 1;
                Destroy(coin);
            }
        }

    }
}
