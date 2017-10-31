using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {


	public float maxOffset;

	public Transform start;
	public GameObject blockPreFab;
	[Range(0,1)]
	public float pickupSpawnProbablity;

	public static int n; 

	private GameObject block;

	private int offset;

    private static ProceduralGeneration instance;

    public static ProceduralGeneration Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<ProceduralGeneration>();
            }
            return instance;
        }
    }

	void Start () {
		block = Instantiate (blockPreFab,start.position,Quaternion.identity) as GameObject;
		n = 1;
		offset = 0;
        SpawnTiles();
	}

    public void SpawnTiles() {
        while (n < 50)
        {
            int randomDirection = Random.Range(0, 2);
            bool spawnPickup = (Random.Range(0f, 1f) < pickupSpawnProbablity) ? true : false;

            if (offset == maxOffset)
                randomDirection = 0;
            else if (offset == -maxOffset)
                randomDirection = 1;
            Vector3 newPos = block.transform.position;
            if (randomDirection == 1)
            {
                newPos.x++;
                offset++;
            }
            else
            {
                newPos = block.transform.position;
                newPos.z++;
                offset--;
            }
            block = Instantiate(blockPreFab, newPos, Quaternion.identity) as GameObject;
            n++;
            if (spawnPickup)
            {
                Vector3 pos = block.transform.position + Vector3.up * 1.5f;
                //Debug.DrawRay(pos, Vector3.up * 100f, Color.red, 1000f);
            }
        }
    }
}
