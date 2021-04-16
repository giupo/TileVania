using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Start is called before the first frame update

  public float moveSpeed = 10;
  public Animator animator;
  void Start() { }

    // Update is called once per frame
  void Update(){
    float horizontalInput = Input.GetAxis("Horizontal");      
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 velocity = new Vector3(horizontalInput, verticalInput, 0);
    bool is_moving = velocity.magnitude > 0.01;
    animator.SetBool("Running", is_moving);
    if (is_moving) {
      transform.Translate(velocity * moveSpeed * Time.deltaTime);
    }
  }
}
