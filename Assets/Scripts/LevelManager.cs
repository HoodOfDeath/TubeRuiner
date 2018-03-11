using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Generator TubeGenerator;
    public GameObject FirstTunnel;
    public Generator ObstacleGenerator;
    public GameObject Player;

    float zOffset = 2*2.1f;
    Vector3 currentSectionPos;
    Vector3 playerDestination;
    Quaternion currentRotation;
    GameObject currentTunnel;
    GameObject currentObstacle;
    int tunnelsPassed = 0;
    float liveTime = 1f;

	void Start ()
    {
        playerDestination = FirstTunnel.transform.position;
        currentSectionPos = FirstTunnel.transform.position;
        currentRotation = FirstTunnel.transform.rotation;
        for (int i = 0; i < 10; i++)
        {
            currentSectionPos.z += zOffset;
            currentTunnel = TubeGenerator.Generate(currentSectionPos, currentRotation);
            Destroy(currentTunnel, liveTime);
            liveTime += 1f;
        }
        Destroy(FirstTunnel, 1f);
        liveTime = 10f;
	}

	void Update ()
    {
        if (Player.transform.position.z >= playerDestination.z)
        {
            playerDestination.z += zOffset;
            tunnelsPassed++;
            tunnelsPassed %= 5;
            currentSectionPos.z += zOffset;
            currentTunnel = TubeGenerator.Generate(currentSectionPos, currentRotation);
            Destroy(currentTunnel, liveTime);
            if (tunnelsPassed == 3)
            {
                currentObstacle = ObstacleGenerator.Generate(currentSectionPos, currentRotation);
                Destroy(currentObstacle, liveTime);
            }
        }
	}
}
