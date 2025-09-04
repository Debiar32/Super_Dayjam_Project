using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Move : MonoBehaviour
{
    
    [SerializeField] private InputAction Move;
    [SerializeField] private InputAction Jump;
    public LayerMask Ground_Layer;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Move_Speed;
    [SerializeField] private float Move_Speed_On_Air;
    [SerializeField] private float Jump_Force;
    public Vector2 Move_Axis;
    //bool Is_Jumping = false;

    [SerializeField] private Animator animator;

    enum Player_States 
    { 
    Idle,
    Move,
    Jump,
    Falling
    }
    Player_States Current_State = Player_States.Idle;


    private void OnEnable()
    {
        Move.Enable();
        Jump.Enable();
      
    }

    private void OnDisable()
    {
        Move.Disable();
        Jump.Disable();
        
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
        if ( Move_Axis.x < 0) {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        if (Move_Axis.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
    }

    private void FixedUpdate()
    {
        switch (Current_State)
        {
            case Player_States.Idle:
               

                if (Move_Axis.x != 0)
                {
                    animator.CrossFade("running", 0.1f);
                    Current_State = Player_States.Move;
                   
                }
                if (Jump.IsPressed() && Ground_Check() == true)
                {
                    animator.CrossFade("jump",0.1f);
                    Current_State = Player_States.Jump;
                }
                break;
            case Player_States.Move:
                rb.linearVelocityX = Move_Axis.x * Move_Speed;
                if (Move_Axis.x == 0) {
                    Current_State = Player_States.Idle;
                }
                if (Jump.IsPressed() && Ground_Check() == true )
                {
                    animator.CrossFade("jump",0.1f);
                    Current_State = Player_States.Jump;
                }
                break;
            case Player_States.Jump:
                Vector2 Jump_Dir = Move_Axis;
                rb.linearVelocity = Vector2.up * Jump_Force;
                StartCoroutine(Jump_Delay());
                if (Ground_Check() == true)
                {
                    Current_State = Player_States.Idle;
                }
                else if (Ground_Check() == false) {
                    StartCoroutine(Falling_Delay());
                    Current_State = Player_States.Falling;
                }
                break;
            case Player_States.Falling:
                //Falling Animation;
                animator.CrossFade("Idle",0.1f);
                    Current_State = Player_States.Idle;
                   
                
                break;
            
               
            
               
        }
        
        bool Ground_Check() {
           return Physics2D.OverlapCircle(transform.position, .5f, Ground_Layer);
        }

        IEnumerator Jump_Delay(){ 
        yield return new WaitForSeconds(.3f);
        }

        IEnumerator Falling_Delay() { 
        yield return new WaitForSeconds(0.5f);
        }

        


    }

    
}


