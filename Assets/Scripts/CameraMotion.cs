using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform Target;
    private Vector3 startPosition; // эта переменная обманывает своим названием. Это дистанция между камерой и игроком
    private Vector3 moveVector;


	void Start ()
    {
        startPosition = transform.position - Target.position;
	}
	
	void Update ()
    {
        CameraMove();
	}

    void CameraMove()
    {
        moveVector = Target.position + startPosition;
        moveVector.x = 0f;
        moveVector.y = 0f;

        transform.position = moveVector; // можно просто делать transform.position = Target.position + powerConst * Vector3.back
                                            // ТОгда все что выше вожно убрать. Включая переменную startPosition.
                                            // И скрипт переименовать в MovementFor
    }
}
