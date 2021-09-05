using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private float _x, _z;
    public float speed = 10f;
    public float jumpSpeed = 300f;
    public  float timeSuperSalto = 0; 
    public GameObject panelPotenciador;
    public Camera cam;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsule;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
        if (Input.mouseScrollDelta.y<0)
        {
            cam.fieldOfView++;
        }
        if (Input.mouseScrollDelta.y>0)
        {
            cam.fieldOfView--;
        }
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            _rigidbody.AddForce(0,jumpSpeed,0); 
        }

        Vector3 _direccion=transform.forward*_z+transform.right*_x;
        _rigidbody.MovePosition(transform.position+_direccion*speed*Time.deltaTime);
    }

    bool IsGrounded() {
        RaycastHit hitInfo;
        if(Physics.SphereCast(transform.position, _capsule.radius, Vector3.down, out hitInfo, (_capsule.height/2f) - _capsule.radius + 0.1f)) {
            return true;
        }
        return false;
    }
}
