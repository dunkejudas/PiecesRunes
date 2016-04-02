using UnityEngine;
using System.Collections;

public class fixedCamera_SN : MonoBehaviour {

    private Vector3 _initialPosition;
    public GameObject _playerHandle;

	// Use this for initialization
	void Start () {
        _initialPosition = this.gameObject.transform.position - _playerHandle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = _initialPosition + _playerHandle.transform.position;
	}
}
