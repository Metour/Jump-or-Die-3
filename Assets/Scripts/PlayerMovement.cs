using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 2f;
    public float jumpForce = 10f;

    private Rigidbody2D body;
    private Animator anim;
    private Animator hit;
    private float dirX;
    public GameObject bombs;
    BoxCollider2D col;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX < 0)
        {
            anim.SetBool("Correr", true);
            transform.rotation = Quaternion.Euler(0,180,0);
            
        }

        else if (dirX > 0)
        {
            anim.SetBool("Correr", true);
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        else
        {
            anim.SetBool("Correr", false); 
        }

        if (Input.GetButtonDown("Jump") && CheckGround.isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Saltar", true);
        }

        if (CheckGround.isGrounded)
        {
            anim.SetBool("Saltar", false);
        }
        else
        {
            anim.SetBool("Saltar", true);
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(dirX * runSpeed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bombas")
        {
            GameManager.Instance.RestarVidas();
            Animator hitAnimator = collision.gameObject.GetComponent<Animator>();
            BoxCollider2D col = collision.gameObject.GetComponent<BoxCollider2D>();
            col.enabled = false;
            hitAnimator.SetBool("Explote", true);
            AudioManager.Instance.BombasSFX();
            StartCoroutine(DestroyBomb(collision.gameObject));
        }

        else if (collision.collider.tag == "Bombas")
        {
            anim.SetBool("Explote", false);
        }

        if (collision.collider.tag == "Estrellas")
        {
            GameManager.Instance.Estrellas();
            AudioManager.Instance.EstrellasSFX();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.layer == 6)
        {
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake());
            //Otra forma
            //StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(1f, 0.05f));
        }
    }
    
    IEnumerator DestroyBomb(GameObject bombs)
    {
        yield return new WaitForSeconds(0.46f);
        Destroy(bombs.gameObject);
    }
}