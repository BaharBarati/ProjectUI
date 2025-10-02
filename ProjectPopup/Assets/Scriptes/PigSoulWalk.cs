using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameObjectWalk : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float dipDistance = 0.5f;
    [SerializeField] private float riseDistance = 2f;
    [SerializeField] private float dipTime = 1f;
    [SerializeField] private float riseTime = 0.08f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool walking;
    private bool facingRight = true;
    private bool busy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        
        anim.SetFloat("Direction",h);
        
        bool hasInput = Mathf.Abs(h) > 0.1f;
        
        anim.SetBool("Walking", hasInput);
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
        if (anim) anim.SetBool("IsBopping", true); 
        rb.gravityScale = 0f;
        
        //with dotween

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
        
        //
        
        if (anim) anim.SetBool("IsBopping", false);

        busy = false;
        rb.gravityScale = 5f;
    }
    
}
// using UnityEngine;
//
// [RequireComponent(typeof(Rigidbody2D))]
// public class GameObjectWalk : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5f;
//
//     [SerializeField] private float dipDistance = 0.5f;
//     [SerializeField] private float riseDistance = 2f;
//     [SerializeField] private float dipTime = 1f;
//     [SerializeField] private float riseTime = 0.08f;
//
//     private Rigidbody2D rb;
//     private Animator anim;
//
//     
//     private bool walking;
//     private bool facingRight = true;
//
//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }
//
//     void Update()
//     {
//         float h = Input.GetAxisRaw("Horizontal"); 
//         
//         if (anim)
//         {
//             anim.SetFloat("Direction", h);
//             bool hasInput = Mathf.Abs(h) > 0.1f;
//             anim.SetBool("Walking", hasInput);
//         }
//         
//         if (Input.GetKeyDown(KeyCode.Space) && anim && !anim.GetBool("IsBopping"))
//         {
//             anim.SetBool("IsBopping", true);
//         }
//     }
//
//     void FixedUpdate()
//     {
//         float h = Input.GetAxisRaw("Horizontal");
//         
//         rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);
//     }
//
//     // ---------
//     public void DipStart()  { StartMoveVertical(-dipDistance,  dipTime,  easeOut:false); }
//     public void RiseStart() { StartMoveVertical(+riseDistance, riseTime, easeOut:true); }
//
//     public void BopDone()
//     {
//         if (anim) anim.SetBool("IsBopping", false);
//     }
//
//     
//     Coroutine vMove;
//     float originalGravity;
//
//     void StartMoveVertical(float deltaY, float duration, bool easeOut)
//     {
//         if (vMove != null) StopCoroutine(vMove);
//         vMove = StartCoroutine(MoveVerticalRB(deltaY, duration, easeOut));
//     }
//
//     System.Collections.IEnumerator MoveVerticalRB(float deltaY, float duration, bool easeOut)
//     {
//         originalGravity = rb.gravityScale;
//         rb.linearVelocity     = new Vector2(rb.linearVelocity.x, 0f);     
//
//         Vector2 from = rb.position;                             
//         Vector2 to   = from + new Vector2(0f, deltaY);
//
//         float t = 0f;
//         var wait = new WaitForFixedUpdate();
//         while (t < duration)
//         {
//             t += Time.fixedDeltaTime;
//             float a = Mathf.Clamp01(t / duration);
//             if (easeOut) a = 1f - Mathf.Pow(1f - a, 3f);        // ease-out 
//             rb.MovePosition(Vector2.Lerp(from, to, a));
//             yield return wait;
//         }
//         
//         vMove = null;
//     }
// }
