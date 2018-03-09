using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWalking : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 1;
    bool moveForward = false;
    RaycastHit hit;

    private CharacterController Player;

    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            moveForward = !moveForward;
        //Engage(moveForward, speed);
        MoveBySight(moveForward, speed);
        //MoveBySight2(moveForward, speed);
    }

    void Engage(bool moveForvard, float speed)
    {
        if (moveForward)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Player.Move(gaze * speed * Time.deltaTime);
        }
    }

    void MoveBySight(bool moveForvard, float speed)
    {
        if (moveForvard)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Physics.Raycast(vrCamera.transform.position, gaze, out hit, 20.0f);
            Vector3 g = hit.point;
            g.z += 1;
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, g, speed * Time.deltaTime);
        }
    }

    void MoveBySight2(bool moveForvard, float speed)
    {
        if (moveForvard)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Physics.Raycast(vrCamera.transform.position, gaze, out hit, 20.0f);
            Vector3 g = hit.point;
            g.z = 0;
            g.y = 0;
            //Player.transform.position = Vector3.MoveTowards(Player.transform.position, g, speed * Time.deltaTime);
            Vector3 g1 = Vector3.MoveTowards(Player.transform.position, g, speed * Time.deltaTime);
            g1.z = 0;
            Player.Move(Vector3.forward * speed * Time.deltaTime + g * Time.deltaTime);
        }
    }



}
