using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelGenerator levelGenerator;

    public float speed = 3f;
    public float speedAdd = 0.1f;
    public float rotationSpeed = 100f;

    public int targetTunnelIndex = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /// Rotation of player
        transform.Rotate(Vector3.forward * Time.deltaTime * Input.GetAxis("Horizontal") * rotationSpeed);

        ///Movement towards next segment of tunnel
        Transform targetTunnel;
        if (levelGenerator.currentTunnelIndex<levelGenerator.tunnels.Length-1)
        {
            targetTunnel = levelGenerator.tunnels[levelGenerator.currentTunnelIndex + 1];
        }
        else
        {
            targetTunnel = levelGenerator.tunnels[0];
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetTunnel.position, step);
        speed += speedAdd * Time.deltaTime;

        ///When reach tunnel's segment generate new at the end
        if (transform.position==targetTunnel.position)
        {
            targetTunnelIndex++;
            levelGenerator.GenerateNewTunnel();
        }
    }
}
