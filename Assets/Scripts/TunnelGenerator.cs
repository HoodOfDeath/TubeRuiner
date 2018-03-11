using UnityEngine;

public class TunnelGenerator : Generator
{
    public GameObject tunnelPrefab;// общее поле вынести в класс родитель

    public override GameObject Generate(Vector3 position, Quaternion rotation)
    {
        GameObject currentTunnel = Instantiate(tunnelPrefab, position, rotation);
        return currentTunnel;
    }
}
