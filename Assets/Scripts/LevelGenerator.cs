using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject tunnelPrefab;
    public GameObject firstTunnel;

    const int startTunnelCount = 10;

    public Transform[] tunnels = new Transform[startTunnelCount];

    float zOffset = 2.1f;

    public int currentTunnelIndex = 1;

    public void GenerateNewTunnel()
    {
        Transform previousTunnelTransform;
        if (currentTunnelIndex == 0)
        {
            previousTunnelTransform = tunnels[tunnels.Length - 1];
        }
        else
        {
            previousTunnelTransform = tunnels[currentTunnelIndex - 1];
        }

        GameObject currentTunnel = Instantiate(tunnelPrefab,
        new Vector3(previousTunnelTransform.position.x, previousTunnelTransform.position.y, previousTunnelTransform.position.z + zOffset),
        new Quaternion(previousTunnelTransform.rotation.x, previousTunnelTransform.rotation.y, previousTunnelTransform.rotation.z, previousTunnelTransform.rotation.w));
        tunnels[currentTunnelIndex] = currentTunnel.transform;
        currentTunnel.name += currentTunnelIndex;

        if (currentTunnelIndex+1>tunnels.Length-1)
        {
            currentTunnelIndex = 0;
        }
        else
        {
            currentTunnelIndex++;
        }

    }

    ///Initialization of tunnel
    void Start ()
    {
        tunnels[0] = firstTunnel.transform;
        for (int i = 1; i <= startTunnelCount; i++)
        {
            GenerateNewTunnel();
        }
	}
}
