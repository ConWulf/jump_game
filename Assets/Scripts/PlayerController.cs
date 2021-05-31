using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerActionControls pac;
    [SerializeField] private float speed, jumpSpeed;

    private void Awake() {
        pac = new PlayerActionControls();
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
