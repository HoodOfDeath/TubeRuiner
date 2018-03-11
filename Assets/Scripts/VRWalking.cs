using UnityEngine;

public class VRWalking : MonoBehaviour
{
    //public Transform vrCamera;
    //private Camera MainCamera;
    const float scale = 10f;
    public float Speed = 1f;
    public float XYSpeed = 5f;
    public bool mod = true;
    bool moveForward = true;
    RaycastHit hit;
    Mod currentMod;
    public Camera MainCam;

    private CharacterController Player;

    void Start()
    {
        
        //Player = GetComponent<CharacterController>();
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
            Vector3 gaze = MainCam.transform.forward * Speed * Time.deltaTime;
            Player.Move(gaze);
        }
    }

    Vector3 PlayerPositionZ = new Vector3(0, 0, 0);
    Vector2 g;
    Vector2 PlayerPositionXY;
    void MoveBySight(bool moveForvard, float Speed)
    {
        if (moveForvard)
        {

            Vector3 gaze = MainCam.transform.forward;
            g = new Vector2(gaze.x, gaze.y) * scale;
            /*if( Physics.Raycast(MainCam.transform.position, gaze, out hit, 20.0f))
            if( hit.collider.tag == "PlayersController" | hit.collider.tag == "Player")
            {
                g = new Vector2( hit.point.x, hit.point.y);
            }//*/
            PlayerPositionXY = transform.position;
            PlayerPositionZ += Vector3.forward * Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(PlayerPositionXY, g, Speed * Time.deltaTime) + PlayerPositionZ;
            Debug.Log(gaze);
        }
    }
}
