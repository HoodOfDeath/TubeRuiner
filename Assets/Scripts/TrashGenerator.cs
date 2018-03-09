using UnityEngine;

public class TrashGenerator : Generator
{
    public GameObject TrashPrefab;

    Vector3[] randVect = { new Vector3(2, 0, 0), new Vector3(-2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, -2, 0), new Vector3(1.4142f, 1.4142f, 0), new Vector3(-1.4142f, 1.4142f, 0), new Vector3(1.4142f, -1.4142f, 0), new Vector3(-1.4142f, -1.4142f, 0) };

    public override GameObject Generate(Vector3 position, Quaternion rotation)
    {
        System.Random rnd = new System.Random();
        int pos = rnd.Next(0, 7);
        if (pos>3)
        {
            rotation.z += 45;
        }
        GameObject currentTunnel = Instantiate(TrashPrefab, position + randVect[pos], rotation);
        return currentTunnel;
    }
}
