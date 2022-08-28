using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{

    SpriteRenderer sprite;
    bool facingRight = true;

    public GameObject bulletPrefabs;
    GameObject bullet;
    public float bulletSpeed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        flipSprite();
        playerAnim();
        Fire();
    }

    void flipSprite()
    {
        if (facingRight == true && Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
            facingRight = false;
        }
        else if (facingRight == false && Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
            facingRight = true;
        }

    }

        void playerAnim()
        {
            float speed = Input.GetAxis("Horizontal");
            anim.SetFloat("speed", Mathf.Abs(speed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

        }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0) && facingRight )
        {
            //shooting code here
            bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
            Destroy(bullet, 1f);
        }
        else if (Input.GetMouseButtonDown(0) && !facingRight)
        {
            bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0f);
            Destroy(bullet, 1f);
        }
    }


}
