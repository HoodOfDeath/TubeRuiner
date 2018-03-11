using UnityEngine;

public class VRWalking : MonoBehaviour
{
    private Camera MainCamera;
    const float scale = 10f;
    public float Speed = 1f;

    private CharacterController Player;

    void Start()
    {
        
        Player = GetComponent<CharacterController>();
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

    Vector3 PlayerPositionZ = new Vector3(0, 0, 0); // Если не используете, удалите
    Vector2 target; // переменную можно мделать локальной, переместить в метод
    Vector2 playerPositionXY; // также как и с target
    Vector2 movementXY;  // также как и с target
    void MoveBySight(float Speed) // переменная Speed глобальная, передавать ее как параметр не нужно
    {

        // В принципе тут все норм, если это работает. 
        Vector3 gaze = MainCamera.transform.forward;
        target = new Vector2(gaze.x, gaze.y) * scale;
        playerPositionXY = transform.position;
        movementXY = (target - playerPositionXY) * Speed*Time.deltaTime;
        Player.Move(new Vector3(movementXY.x, movementXY.y, Speed*Time.deltaTime));
    }
}
