using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 0.01f;
    public float speedAdd = 0.1f;
    public float rotationSpeed = 100f;

    public int targetTunnelIndex = 0;

    /*public LevelGenerator levelGenerator;
	// Use this for initialization
	void Start ()
    {
		
	}//*/
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currentPos = transform.position;
        Vector3 destinationPos = new Vector3(currentPos.x, currentPos.y, currentPos.z + 2f);
        transform.position = Vector3.MoveTowards(currentPos, destinationPos, speed); 
        transform.Rotate(Vector3.forward * Time.deltaTime * Input.GetAxis("Horizontal") * rotationSpeed);
        /*
        /// Rotation of player

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
        }//*/
    }
}
