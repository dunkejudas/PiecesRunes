using UnityEngine;
using System.Collections;

public class constructorControl_SN : MonoBehaviour {

    public GameObject[] _obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider col)
    {
        Debug.Log(col.transform.position);
        if (col.gameObject.tag == "gameGround" && !col.gameObject.GetComponent<gameGroundScript_SN>()._hasSpawnedNew)
        {
            spawnNewBlock(col.gameObject.transform.GetChild(0).transform.position,col.gameObject);
        }
    }

    void spawnNewBlock(Vector3 pos, GameObject p)
    {
        p.GetComponent<gameGroundScript_SN>()._hasSpawnedNew = true;
        Instantiate(_obj[Random.Range(0, _obj.Length)], pos, Quaternion.identity);
    }
}
