using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WalkJumpFire : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX;

    [SerializeField]
    float moveSpeed = 5f, jumpForce = 600f, bulletSpeed = 500f;

    bool facingRight = true;
    Vector3 localScale;

    public Transform barrel;
   
    public Rigidbody2D bullet;

    public GameObject LineDrawer, vida1, vida2, vida3, vida4, vida5;
    public float estamina2;

    public int vida;
    public Animator animator;
    




    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        vida = 3;


        animator = GetComponent<Animator>();

        
        



    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
       

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
            
          

        }
        //if (CrossPlatformInputManager.GetButtonDown("Jump") == false && rb.velocity.y == 0)
        //{
        //    animator.SetBool("taPulando", false);
        //}




        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            Fire();

        if (vida > 5)
        {
            vida = 5;
        }

        if (vida == 5)
        {
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
        }

        if (vida == 4)
        {
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(false);
        }

        if (vida == 3)
        {
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
        }

        if (vida == 2)
        {
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(false);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
        }

        if (vida == 1)
        {
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(false);
            vida3.gameObject.SetActive(false);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
        }

        if (vida <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene(0);
        }

        //estamina2 = LineDrawer.GetComponent<LineDrawer>().estamina;

    }

   
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (dirX != 0)
        {
            animator.SetBool("taCorrendo", true);
        }
        else
        {
            animator.SetBool("taCorrendo", false);
        }

        
        
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else
            if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            //animator.SetBool("taPulando", true);

           

        }
       



    }

    void Fire()
    {
        var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        firedBullet.AddForce(barrel.up * bulletSpeed);
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("armadilha2"))
        {
            vida--;
        }

        if (Other.gameObject.CompareTag("armadilha"))
        {
            vida = 0;
        }

        if (Other.gameObject.CompareTag("vida"))
        {
            vida++;
        }

        if (Other.gameObject.CompareTag("tinta"))
        {
            estamina2 = 25;
            //Destroy(gameObject);
            Debug.Log("tinta + 25");
        }


    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
        {
            transform.parent = col.transform;
        }

        
    }

    public virtual void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
        {
            transform.parent = null;
        }
    }


}
