using UnityEngine;

public class VRWalking : MonoBehaviour
{
    private Camera MainCamera;
    const float scale = 10f;
    public float Speed = 1f;
    public GvrReticlePointer ray;

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

    void MoveBySight()
    {
        Vector2 rayXY = ray.CurrentRaycastResult.worldPosition;
        Vector2 playerPositionXY = transform.position;
        Vector2 movementXY = (rayXY - playerPositionXY) * Speed*Time.deltaTime;
        Player.Move(new Vector3(movementXY.x, movementXY.y, Speed*Time.deltaTime));
    }
}
