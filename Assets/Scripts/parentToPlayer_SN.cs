using UnityEngine;
using System.Collections;

public class parentToPlayer_SN : MonoBehaviour {

    private Vector3 _initialPosition;
    public GameObject _playerHandle;

    public bool _includeY;

    // Use this for initialization
    void Start()
    {
        _initialPosition = this.gameObject.transform.position - _playerHandle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (_includeY)
            this.gameObject.transform.position = _initialPosition + _playerHandle.transform.position;
        else
            this.gameObject.transform.position = new Vector3(_initialPosition.x + _playerHandle.transform.position.x, _initialPosition.y, _initialPosition.z + _playerHandle.transform.position.z);
    }
}
