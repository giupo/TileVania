using UnityEngine;

public class Bullet : MonoBehaviour {
  [SerializeField] float speed = 10;

  public Vector2 direction = Vector2.zero;

  Rigidbody2D body;
  void Start() {
    body = GetComponent<Rigidbody2D>();    
  }

    
  void FixedUpdate() {
    body.velocity = direction * speed;      
  }
}
