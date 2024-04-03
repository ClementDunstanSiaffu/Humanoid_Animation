using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movespeed = 10f;
    public float rotatespeed = 75f;

    public float jumpVelocity = 5f;
    private Rigidbody rb;

    private float vinput;
    private float hinput;
    public float distanceFromGround = 0.1f;
    public LayerMask groundLayer;
    private CapsuleCollider _col;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    private GameBehaviour _gameManager;
    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    void Start(){
        rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
        _gameManager.initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       vinput = Input.GetAxis("Vertical") * movespeed;
       hinput = Input.GetAxis("Horizontal") * rotatespeed;

       Vector3 rotation = Vector3.right * hinput;
       Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

       rb.MovePosition(transform.position + transform.forward * vinput * Time.fixedDeltaTime);
       rb.MoveRotation(rb.rotation * angleRot);

       if (IsGrounded() &&  Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpVelocity,ForceMode.Impulse);
            playerJump();
       }

       
        // use if (Input.GetMouseButtonDown(0)) --- 0 = left,1 = right,2 - middle or wheel scroll in the mouse
        // untill you connect with mouse 

       if (Input.GetKeyDown(KeyCode.Tab)){
            GameObject newBullet = Instantiate(bullet,transform.position + new Vector3(1,0,0),transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = transform.forward * bulletSpeed;
       }


    //    this.transform.Translate(Vector3.forward * vinput * Time.deltaTime);
    //    this.transform.Rotate(Vector3.up * hinput * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Enemy"){
            _gameManager.HP -= 1;
        }
    }

    private bool IsGrounded(){
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,_col.bounds.min.y,_col.bounds.min.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center,capsuleBottom,distanceFromGround,groundLayer,QueryTriggerInteraction.Ignore);
        return grounded;
    }
}
