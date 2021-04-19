using UnityEngine;


public class PlayerController : MonoBehaviour {
  // Start is called before the first frame update


  // editable properties
  [SerializeField] float move_speed = 1;
  [SerializeField] float jump_speed = 2;
  [SerializeField] GameObject arrowPrefab;

  // references
  private Animator animator;
  private Rigidbody2D body;  
  private Collider2D collider;
  // state
  bool is_jumping = false;
  void Start() { 
    animator = GetComponent<Animator>();
    body = GetComponent<Rigidbody2D>();
    collider = GetComponent<Collider2D>();
  }

  // Update is called once per frame
  void Update() {
    if (Mathf.Abs(body.velocity.x) > Mathf.Epsilon) {
      animator.SetBool("Running", true);
    } else {
      animator.SetBool("Running", false);
    }
  }

  void FixedUpdate() {
    handle_X_movement();
    handle_Y_movement();    
  }

  private void handle_Y_movement() {
    // if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;    
    if (is_jumping) return;
    
    float horizontal_input = Input.GetAxis("Vertical");
    if (horizontal_input <= Mathf.Epsilon) return;

    // body.velocity += Vector2.up * jump_speed;
    body.AddForce(Vector2.up * jump_speed, ForceMode2D.Impulse);
    is_jumping = true;    
  }

  private void handle_X_movement() {
    float horizontal_input = Input.GetAxis("Horizontal");

    Vector2 direction = new Vector2(horizontal_input, 0);
    if (direction.magnitude <= 0.11f) { return; }      
    
    
    if (horizontal_input > 0) FlipRight();
    if (horizontal_input < 0) FlipLeft();
      
    if (body.velocity.x >= move_speed) return;

    Debug.Log("direction: " + direction);

    body.AddForce(direction * move_speed);    
  }

  void FlipLeft() {
    Vector3 scale = transform.localScale;
    scale.x = -1 * Mathf.Abs(scale.x);
    transform.localScale = scale;
  }

  void FlipRight() {
    Vector3 scale = transform.localScale;
    scale.x = Mathf.Abs(scale.x);
    transform.localScale = scale;
  }

  private void OnCollisionEnter2D(Collision2D other) {    
    if(other.gameObject.tag == "Foreground") {
      is_jumping = false;
    }  
  }
}
