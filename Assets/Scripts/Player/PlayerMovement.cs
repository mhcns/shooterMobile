using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6;

    private Vector3 movement;
    private Rigidbody rb;
    private Animator animator;
    private PlayerShooting playershooting;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playershooting = GetComponentInChildren<PlayerShooting>();
    }

    private void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        float rotH = CrossPlatformInputManager.GetAxisRaw("RotHorizontal");
        float rotV = CrossPlatformInputManager.GetAxisRaw("RotVertical");

        Move(h,v);
        Turning(rotH, rotV);
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {
        Vector3 rot = new Vector3(h, 0, v);
        if(rot != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rot);
            playershooting.Shoot();
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("Walking", walking);
    }
}
