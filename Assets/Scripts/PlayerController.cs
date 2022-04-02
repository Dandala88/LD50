using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpReleaseTime;
    [SerializeField]
    private float jumpHangTime;
    [SerializeField]
    private float gravityScale;


    private Vector2 _input;

    private CharacterController cc;

    private bool jumping;

    private Vector3 vertMovement;
    private Vector3 horMovement;
    private bool canCancelJump;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Mathf.Abs(_input.x) > float.Epsilon)
        {
            transform.Rotate(0f, _input.x * rotationSpeed * Time.deltaTime, 0f);
        }

        horMovement = _input.y * moveSpeed * transform.forward * Time.deltaTime;

        if (jumping)
        {
            vertMovement = jumpForce * Vector3.up * Time.deltaTime;
        }

        if(!cc.isGrounded)
            vertMovement += Physics.gravity * gravityScale * Time.deltaTime;

        cc.Move(horMovement + vertMovement);
    }

    public void Move(Vector2 input)
    {
        _input = input;
    }

    public void Jump()
    {
        if(cc.isGrounded && !jumping)
        {
            jumping = true;
            StartCoroutine(JumpingCoroutine());
        }
    }

    private IEnumerator JumpingCoroutine()
    {
        float pressedJumpTime = 0;
        canCancelJump = true;
        yield return new WaitForSeconds(jumpReleaseTime);
        canCancelJump = false;
        yield return new WaitForSeconds(jumpHangTime);
        jumping = false;
    }

    public void JumpCanceled()
    {
        if (canCancelJump)
        {
            StopAllCoroutines();
            jumping = false;
        }
    }
}
