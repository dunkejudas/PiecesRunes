using UnityEngine;
using System.Collections;

public class monsterController_SN : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        this.transform.Translate(0, 0, 1f*0.25f);
        /*
        Rigidbody _rb = GetComponent<Rigidbody>();

        if (_rb.velocity.magnitude < 55)
            _rb.velocity = new Vector3(0, 0, 10);
            */
    }
}
