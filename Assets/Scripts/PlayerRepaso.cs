using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepaso : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    private float horizontal;

    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 10;
    
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundSensor;
    [SerializeField] float sensorRadius;
    [SerializeField] LayerMask sensorLayer;

    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    //Se ejecuta una vez por frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("isRunning", true);
        }

        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isRunning", true);
        }

        else if(horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }

    
    void FixedUpdate()
    {
        //Vector2 porque es 2D si fuera 3D seria 3 porque tiene 3 ejes (x,y,z).
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Comprobar el numero de la layer Ground que coincida (En este caso es la 7).
        if(coll.gameObject.layer == 7)
        {
            anim.SetBool("isJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Star")
        {
            GameManagerRepaso.Instance.LoadLevel(1);
        }

        else if(other.gameObject.tag == "Coin")
        {
            GameManagerRepaso.Instance.AddCoin(other.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }
}
