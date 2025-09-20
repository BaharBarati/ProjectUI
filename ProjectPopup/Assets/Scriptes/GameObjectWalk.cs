using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleWalker : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float dipDistance = 0.5f;
    [SerializeField] private float riseDistance = 2f;
    [SerializeField] private float dipTime = 1f;
    [SerializeField] private float riseTime = 0.08f;

    private Rigidbody2D rb;

    private bool walking;
    private bool facingRight = true;
    private bool busy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        
        
        bool hasInput = Mathf.Abs(h) > 0.1f;
        
        if (Input.GetKeyDown(KeyCode.Space) && !busy)
        {
            StartCoroutine(Bop());
        }
        
        // if (hasInput && !walking)
        // {
        //     walking = true;
        //     anim.ResetTrigger("StopWalk");
        //     anim.SetTrigger("StartWalk");
        // }
        //
        // if (!hasInput && walking)
        // {
        //     walking = false;
        //     anim.ResetTrigger("StartWalk");
        //     anim.SetTrigger("StopWalk");
        // }
        //
        // if (h > 0 && !facingRight)
        //     Flip();
        // else if (h < 0 && facingRight)
        //     Flip();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(h * moveSpeed, 0f);
    }

    // private void Flip()
    // {
    //     facingRight = !facingRight;
    //     Vector3 scale = transform.localScale;
    //     scale.x *= -1;
    //     transform.localScale = scale;
    // }

    System.Collections.IEnumerator Bop()
    {
        busy = true;

        Vector3 startPos = transform.position;
        Vector3 dipPos   = startPos + Vector3.down * dipDistance;
        Vector3 risePos  = dipPos   + Vector3.up   * riseDistance;
        
        float t = 0f;
        while (t < dipTime)
        {
            t += Time.deltaTime;
            float a = Mathf.Clamp01(t / dipTime);
            transform.position = Vector3.Lerp(startPos, dipPos, a);
            yield return null;
        }
        
        t = 0f;
        while (t < riseTime)
        {
            t += Time.deltaTime;
            float a = Mathf.Clamp01(t / riseTime);
            a = 1f - Mathf.Pow(1f - a, 3f); // ease-out
            transform.position = Vector3.Lerp(dipPos, risePos, a);
            yield return null;
        }
        

        busy = false;
    }
    
}