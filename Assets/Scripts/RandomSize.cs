using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour {

	void Start () {
        transform.localScale += new Vector3(0, Random.Range(0,10), 0);
	}

	void Update () {
		
	}
}