using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWalking : MonoBehaviour
{
    public Transform vrCamera;
    private Camera MainCamera;
    public float Speed = 1f;
    public float XYSpeed = 5f;
    public bool mod = true;
    bool moveForward = true;
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
        //MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            moveForward = !moveForward;
        currentMod(moveForward, Speed);
    }

    delegate void Mod(bool moveForvard, float Speed);

    void Engage(bool moveForvard, float Speed)
    {
        if (moveForward)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            Player.Move(gaze * Speed * Time.deltaTime);
        }
    }

    Vector3 PlayerPositionZ = new Vector3(0, 0, 0);
    Vector2 g;
    Vector2 PlayerPositionXY;
    void MoveBySight(bool moveForvard, float Speed)
    {
        if (moveForvard)
        {
            Vector3 gaze = vrCamera.TransformDirection(Vector3.forward);
            if( Physics.Raycast(vrCamera.transform.position, gaze, out hit, 20.0f))
            if( hit.collider.tag == "PlayersController" | hit.collider.tag == "Player")
            {
                g = new Vector2( hit.point.x, hit.point.y);
            }
            PlayerPositionXY = Player.transform.position;
            PlayerPositionZ += Vector3.forward * Speed * Time.deltaTime;
            Player.transform.position = Vector3.MoveTowards(PlayerPositionXY, g, Speed * Time.deltaTime) + PlayerPositionZ;
            Debug.Log(g);
        }
    }
}
