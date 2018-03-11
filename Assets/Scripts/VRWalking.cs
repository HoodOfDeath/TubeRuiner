using UnityEngine;

public class VRWalking : MonoBehaviour
{
    private Camera MainCamera;
    const float scale = 10f;
    public float Speed = 1f;

    private CharacterController Player;

    void Start()
    {
        
        //Player = GetComponent<CharacterController>();
        MainCamera = Camera.main;
    }

    void Update()
    {
        MoveBySight(Speed);
    }

    //delegate void Mod(bool moveForvard, float Speed);

    /*void FirstPersonMovement(bool moveForvard, float Speed)
    {
        if (moveForward)
        {
            Vector3 gaze = MainCam.transform.forward * Speed * Time.deltaTime;
            Player.Move(gaze);
        }
    }//*/

    Vector3 PlayerPositionZ = new Vector3(0, 0, 0);
    Vector2 g;
    Vector2 PlayerPositionXY;
    void MoveBySight(float Speed)
    {
        Vector3 gaze = MainCamera.transform.forward;
        g = new Vector2(gaze.x, gaze.y) * scale;
        PlayerPositionXY = transform.position;
        PlayerPositionZ += Vector3.forward * Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(PlayerPositionXY, g, Speed * Time.deltaTime * 5) + PlayerPositionZ;
        Debug.Log(gaze);
    }
}
