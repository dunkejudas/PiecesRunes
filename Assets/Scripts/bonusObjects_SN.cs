using UnityEngine;
using System.Collections;

public class bonusObjects_SN : MonoBehaviour {

    public bool _activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!_activated)
            {
                _activated = true;
                this.transform.Translate(Vector3.up * 10);
                Destroy(this);
            }
        }
    }
}
