using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public bool IsGrounded = true;
    public float runSpeed = 5f;
    public float jumpSpeed = 25f;
    public int Coins = 0;
    public Text CoinsText;
    public Transform GroundCheck;
    public Transform GroundCheck_L;
    public Transform GroundCheck_R;
    public Transform music;
    public Transform coinPick;
    public GameObject bullet;
    public Transform bulletPos;
    public bool canShoot = true;
    public int health = 5;
    public float fireCooldown = 1f;
    public Color color;


    public bool isWalking = false;

    private bool lookRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        //anim = GetComponent<Animator>();
        //Instantiate(music);
    }

    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
        float move = Input.GetAxis("Horizontal");

        transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        //anim.SetBool("isWalking", isWalking);
        //anim.SetBool("isGrounded", IsGrounded);
        //anim.SetInteger("health", health);

        /*if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_L.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_R.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }*/
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector2(runSpeed * Time.deltaTime, 0);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector2(-runSpeed * Time.deltaTime, 0);
            sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector2(0, runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector2(0, -runSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        if (move > 0 && !lookRight)
        {
            Flip();
        }
        else if (move < 0 && lookRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            canShoot = false;
            StartCoroutine(FireCoolDown());
        }
    }

    public void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0, 180f, 0);
    }

    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(fireCooldown);
        canShoot = true;
        yield return null;
    }

    public void Damage(int amount)
    {
        Debug.Log("working damage");
        health -= amount;
        //update hearths ui
        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator PlayDamageAnim()
    {
        color = Color.red;
        yield return new WaitForSecondsRealtime(1);
        color = Color.white;
        yield return null;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        //play death anim
        health = 5;
        SceneManager.LoadScene(0);
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.name.Contains("coin"))
        {
            Destroy(other.gameObject);
            Instantiate(coinPick);
            Coins++;
            if (Coins < 10)
            {
                CoinsText.text = ("0") + Coins.ToString();
            }
            else
            {
                CoinsText.text = Coins.ToString();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }
}
