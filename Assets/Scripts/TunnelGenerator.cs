using UnityEngine;

public class TunnelGenerator : Generator
{
    public GameObject tunnelPrefab;

    public override GameObject Generate(Vector3 position, Quaternion rotation)
    {
        GameObject currentTunnel = Instantiate(tunnelPrefab, position, rotation);
        return currentTunnel;
    }
}
