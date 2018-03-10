using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWalking : MonoBehaviour
{
    public Transform vrCamera;
    private Camera MainCamera;
    public float speed = 1;
    public bool mod = true;
    bool moveForward = false;
    RaycastHit hit;
    Mod currentMod;

    private CharacterController Player;

    void Start()
    {
        Player = GetComponent<CharacterController>();
        if (mod)
        {
            currentMod = MoveBySight;
        }
        else
        {
            currentMod = Engage;
        }
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            moveForward = !moveForward;
        currentMod(moveForward, speed);
    }

    delegate void Mod(bool moveForvard, float speed);

    void Engage(bool moveForvard, float speed)
    {
        if (moveForward)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Player.Move(gaze * speed * Time.deltaTime);
        }
    }

    Vector3 PlayerPositionZ = new Vector3(0, 0, 0);
    void MoveBySight(bool moveForvard, float speed)
    {
        if (moveForvard)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Physics.Raycast(vrCamera.transform.position, gaze, out hit, 20.0f);
            Vector2 g = hit.point;
            Vector2 PlayerPositionXY = Player.transform.position;
            PlayerPositionZ += Vector3.forward * speed * Time.deltaTime;
            Player.transform.position = Vector3.MoveTowards(PlayerPositionXY, g, speed * Time.deltaTime) + PlayerPositionZ;
        }
    }
}
