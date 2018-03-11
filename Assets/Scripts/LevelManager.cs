using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Generator TubeGenerator;
    public GameObject FirstTunnel; // настройте префаб сразу и FirstTunnel можно удалить от сюда и с сцены вообще
    public Generator ObstacleGenerator;
    public GameObject Player; // Можно передавать только Transform

    float zOffset = 2*2.1f;    // 
    Vector3 currentSectionPos; // перенести логику связанную с вычислением позиции для генерации новой секции тунеля в TunnelGenerator
    Vector3 playerDestination;  // можно убрать, ниже будет понятно почему
    Quaternion currentRotation; // тоже можно убрать, если сразу настроить как надо FirstTunnel
    GameObject currentTunnel; // можно запоминать только позишн последнего созданного туннеля
    GameObject currentObstacle; // никак не используете эту переменную
    int tunnelsPassed = 0;
    float liveTime = 1f;

	void Start ()
    {
        InitialTunnel();
    }

    void InitialTunnel()
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
        CreateTunnelSection();
    }

    void CreateTunnelSection()
    {
        // создать локальную булевскую переменную типо bool isNeedToCreateTunnel = Player.transform.position.z >= lastSectionPos.z - 10*zOffset
        // и поместить ее в if. Так код читаемее. Или можно метод приватный сделать, возвращающий bool IsNeedToCreateTunnel()
        if (Player.transform.position.z >= playerDestination.z) // вынести if из метода. Или переименовать метод в TryToCreateTunnel
        {
            playerDestination.z += zOffset;
            tunnelsPassed++;
            tunnelsPassed %= 5;
            currentSectionPos.z += zOffset;
            currentTunnel = TubeGenerator.Generate(currentSectionPos, currentRotation);
            Destroy(currentTunnel, liveTime);
            if (tunnelsPassed == 3) // метод называется CreateTunnel. Создание препятствий тоже вынести из метода
            {
                currentObstacle = ObstacleGenerator.Generate(currentSectionPos, currentRotation);
                Destroy(currentObstacle, liveTime);
            }
        }
    }
}
