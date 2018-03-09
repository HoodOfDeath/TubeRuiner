using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private Transform Target;
    private Vector3 startPosition;
    private Vector3 moveVector;


	void Start ()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position - Target.position;
	}
	
	void Update ()
    {
        CameraMove();
	}

    void CameraMove()
    {
        moveVector = Target.position + startPosition;
        moveVector.x = 0;
        moveVector.y = 2.5f;

        transform.position = moveVector;
    }
}
