using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Move : MonoBehaviour
{
    
    [SerializeField] private InputAction Move;
    [SerializeField] private InputAction Jump;
    [SerializeField] private InputAction Dragging;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Move_Speed;
    [SerializeField] private float Jump_Force;
     public Vector2 Move_Axis;

    [SerializeField] private Animator animator;




    private void OnEnable()
    {
        Move.Enable();
        Jump.Enable();
        Dragging.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
        Jump.Disable();
        Dragging.Disable();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_Axis = Move.ReadValue<Vector2>();
        Move_Axis.Normalize();
        
    }

    private void FixedUpdate()
    {
        
        rb.linearVelocityX = Move_Axis.x * Move_Speed * Time.fixedDeltaTime;
        

        if (Jump.IsPressed()) {
            rb.linearVelocityY = 2f;
        }
        

        

        
    }
}
