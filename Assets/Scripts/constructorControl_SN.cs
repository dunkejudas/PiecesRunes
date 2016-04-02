using UnityEngine;
using System.Collections;

public class constructorControl_SN : MonoBehaviour {

    public GameObject[] _obj;
    public GameObject _playerHandle;
    public LayerMask _groundLayerMask;

    public GameObject[] _bonusObjs;
    public bool _randomSpawnBonusObjects;

	// Use this for initialization
	void Start () {
        StartCoroutine(randomSpawn());
    }
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator randomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            if (_randomSpawnBonusObjects)
                spawnNewFloatingItem(Random.Range(1, 8));
        }
    }

    void OnTriggerExit(Collider col)
    {
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

    void spawnNewFloatingItem(int amount, bool random = false)
    {
        Vector3 tempPos = new Vector3(_playerHandle.transform.position.x, _playerHandle.transform.position.y + 10, this.transform.position.z);
        Ray r;
        int randomIndex;
        Vector3 newPos;
        RaycastHit hit;
        for (int i = 0; i < amount; i++)
        {
            r = new Ray(tempPos + new Vector3(0,0,(i*2)), -Vector3.up);
            Physics.Raycast(r, out hit, 50.0f, _groundLayerMask);
            newPos = hit.point + new Vector3(0, 3, 0);
            randomIndex = Random.Range(0, _bonusObjs.Length);
            Debug.Log(randomIndex);
            Instantiate(_bonusObjs[randomIndex], newPos, Quaternion.identity);
        }
    }
}
