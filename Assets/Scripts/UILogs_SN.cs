using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILogs_SN : MonoBehaviour {

    public GameObject _dataObj01;
    public GameObject _dataObj02;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "Magnitude: "+_dataObj01.GetComponent<Rigidbody>().velocity.magnitude+"\n Alive: "+_dataObj02.GetComponent<customCharacterController_SN>().isAlive();
	}
}
