using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Start is called before the first frame update

  [SerializeField] float moveSpeed = 10;
  [SerializeField] private Animator animator;
  [SerializeField] private Rigidbody2D body;

  void Start() { }

    // Update is called once per frame
  void Update(){
    float horizontalInput = Input.GetAxis("Horizontal");      
    float verticalInput = Input.GetAxis("Vertical");

    Debug.Log("DIocane");

    Vector3 velocity = new Vector3(horizontalInput, verticalInput, 0);
    bool is_moving = velocity.magnitude > Mathf.Epsilon;
    animator.SetBool("Running", is_moving);
    if (is_moving) transform.Translate(velocity * moveSpeed * Time.deltaTime);
  }
}
