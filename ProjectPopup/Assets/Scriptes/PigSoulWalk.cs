using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleWalker : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool walking;
    private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        bool hasInput = Mathf.Abs(h) > 0.01f;
        
        if (hasInput && !walking)
        {
            walking = true;
            anim.ResetTrigger("StopWalk");
            anim.SetTrigger("StartWalk");
        }
        
        if (!hasInput && walking)
        {
            walking = false;
            anim.ResetTrigger("StartWalk");
            anim.SetTrigger("StopWalk");
        }
        
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(h * moveSpeed, 0f);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}