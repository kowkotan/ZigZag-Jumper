using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector3 dir;

    public float speed = 10f;

	void Start () {
        dir = Vector3.zero;
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else {
                dir = Vector3.forward;
            }
        }

        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);
	}
}
