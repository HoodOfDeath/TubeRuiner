using UnityEngine;

public class TrashGenerator : Generator
{
    public GameObject TrashPrefab; // общее поле вынести в класс родитель

    Vector3[] randVect = { 
        new Vector3(2, 0, 0), new Vector3(-2, 0, 0), new Vector3(0, 2, 0), 
        new Vector3(0, -2, 0), new Vector3(1.4142f, 1.4142f, 0), new Vector3(-1.4142f, 1.4142f, 0), 
        new Vector3(1.4142f, -1.4142f, 0), new Vector3(-1.4142f, -1.4142f, 0), new Vector3(0,0,0) };
        
    Vector3 rotation = new Vector3(0, 0, 45);

    public override GameObject Generate(Vector3 position, Quaternion Rotation)
    {
        System.Random rnd = new System.Random();
        int pos = rnd.Next(0, 8);
        GameObject currentObstacle = Instantiate(TrashPrefab, position + (randVect[pos] * 2), Rotation);
        if (pos>3)
        {
            currentObstacle.transform.eulerAngles = rotation;
        }
        return currentObstacle;
    }
}
