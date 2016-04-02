using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class customCharacterController_SN : MonoBehaviour {

    private Vector3 _velocity;
    private bool _jump;
    private bool _inAir;

    private Rigidbody _rb;

    private bool _alive = true;

    public LayerMask _groundMask;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (!_jump)
                _jump = true;
        }
    }

    void FixedUpdate()
    {



        if (!_alive)
        {
            this.GetComponent<Rigidbody>().freezeRotation = false;
            _rb.AddTorque(_rb.angularVelocity * 2);
            _rb.drag = 1.3f;
            _rb.angularDrag = .3f;
            return;
        }

        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            if (_inAir && this.GetComponent<Rigidbody>().angularVelocity.magnitude < 5.0f)
                this.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 0));
        } else
        {
            if (_inAir)
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.Slerp(this.GetComponent<Rigidbody>().angularVelocity, Vector3.zero, 0.01f);
        }

        if (this.GetComponent<Rigidbody>().velocity.z < 15)
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,20));

        Ray ray = new Ray(transform.position + (Vector3.up * .1f), -Vector3.up);

        //If walking on ground
        if (!_inAir)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,5.0f,_groundMask))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.FromToRotation(Vector3.up, hit.normal),0.2f);
            }

        }

        if (_jump && !_inAir)
        {
            Debug.Log("JUMP!");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, _rb.velocity.magnitude * 40, 0));
            _jump = false;
            _inAir = true;

            this.GetComponent<Rigidbody>().freezeRotation = false;
        }



    }

    public void onHitHead()
    {
        if (_inAir)
        {
            _alive = false;
            Debug.Log("DEATH!");
            StartCoroutine("reloadLevel");
        }
    }

    public IEnumerable reloadLevel()
    {
        yield return new WaitForSeconds(1.0f);

        Application.LoadLevel(Application.loadedLevel);
    }

    public bool isAlive()
    {
        return _alive;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (_inAir)
        {

            if(!col.collider.isTrigger && col.gameObject.tag == "gameGround_Collider")
                {
                    Debug.Log("HIT GROUND!");
                    _inAir = false;
                    this.GetComponent<Rigidbody>().freezeRotation = true;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }
     }

}   
