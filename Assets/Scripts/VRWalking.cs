using UnityEngine;

public class VRWalking : MonoBehaviour
{
    private Camera MainCamera;
    const float scale = 10f;
    public float Speed = 1f;
    RaycastHit gazeRay;

    private CharacterController Player;
    
    void Start()
    {
        
        Player = GetComponent<CharacterController>();
        MainCamera = Camera.main;
        
    }

    void Update()
    {
        MoveBySight();
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
    Vector3 Plane = new Vector3(0, 0, 1);
    /*void MoveBySight()
    {
        Vector3 gaze = MainCamera.transform.forward;
        Vector2 target = new Vector2(gaze.x, gaze.y) * scale;
        Vector2 playerPositionXY = transform.position;
        Vector2 movementXY = (target - playerPositionXY) * Speed * Time.deltaTime;
        Player.Move(new Vector3(movementXY.x, movementXY.y, Speed * Time.deltaTime));
    }//*/

    void MoveBySight()
    {
        
        Vector3 gaze = MainCamera.transform.forward;
        Vector3 temp = Vector3.ProjectOnPlane(gaze * 10, Plane);
        Vector2 target = new Vector2(temp.x, temp.y);
        Vector2 playerPositionXY = transform.position;
        Vector2 movementXY = (target - playerPositionXY) * Speed * Time.deltaTime;
        Player.Move(new Vector3(movementXY.x, movementXY.y, Speed * Time.deltaTime)); //*/
    }
}
