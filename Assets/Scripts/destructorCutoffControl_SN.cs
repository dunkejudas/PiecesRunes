using UnityEngine;
using System.Collections;

public class destructorCutoffControl_SN : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "gameGround")
            Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
