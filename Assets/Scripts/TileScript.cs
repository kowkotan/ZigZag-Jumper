using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            ProceduralGeneration.Instance.SpawnTiles();
            StartCoroutine(Kill());
        }
    }

    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        transform.parent.gameObject.AddComponent<Rigidbody>();
        transform.parent.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, -1.0f, 0.0f);
        Destroy(transform.parent.gameObject, 2);
        ProceduralGeneration.n--;
    }
}
