using UnityEngine;
using System.Collections;

public class characterDeathCollider_SN : MonoBehaviour {

    public LayerMask _layerToHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        //Debug.Break();
        Debug.Log(col.collider.isTrigger + " IstRigger: "+col.gameObject.tag);
        if (!col.collider.isTrigger & col.gameObject.tag == "gameGround_Collider")
            this.transform.parent.GetComponent<customCharacterController_SN>().onHitHead();
    }
}
