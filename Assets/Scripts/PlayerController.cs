using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Animator), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Collects collects;

    private Rigidbody rb;
    private Animator animator;

    public Animator Animator { get { return animator; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3 (joystick.Horizontal * moveSpeed,rb.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("isRunning", true);
        }
        else
            animator.SetBool("isRunning", false);
    }

    public void kek()
    {
        collects.puck();
    }
}
