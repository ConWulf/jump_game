using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerActionControls pac;
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;
    private Rigidbody2D rb;
    private Collider2D coll;
    

    private void Awake() {
        pac = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnEnable() {
        pac.Enable();
    }

    private void OnDisable() {
        pac.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        pac.Land.Jump.performed += _ => Jump();
    }

    private void Jump() {
        if(IsGrounded()) {
            Physics.gravity.y * 2;
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded() {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= coll.bounds.extents.x;
        topLeftPoint.y += coll.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += coll.bounds.extents.x;
        bottomRightPoint.y -= coll.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    // Update is called once per frame
    void Update()
    {
       float movementValue = pac.Land.Move.ReadValue<float>();
       Vector3 currentPosition = transform.position;
       currentPosition.x += movementValue * speed * Time.deltaTime;
       transform.position = currentPosition;
    }
}
