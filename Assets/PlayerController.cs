using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
  // Start is called before the first frame update

  [SerializeField] float moveSpeed = 10;
  
  private Animator animator;
  private Rigidbody2D body;

  void Start() { 
    animator = GetComponent<Animator>();
    body = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    animator.SetBool("Running", is_moving());
  }

  void FixedUpdate() {
    float horizontalInput = Input.GetAxis("Horizontal");      
    float verticalInput = Input.GetAxis("Vertical");

    if (horizontalInput > 0) FlipRight();
    if (horizontalInput < 0) FlipLeft();

    Vector2 direction = new Vector2(horizontalInput, verticalInput);
    Debug.Log(direction);
    if (direction.magnitude > Mathf.Epsilon) {
      body.velocity = direction * moveSpeed;
    }
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

  bool is_moving() {
    return body.velocity.magnitude > 0f;
  }
}
