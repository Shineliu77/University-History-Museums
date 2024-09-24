using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    CharacterController m_Controller;
    PlayerInputHandler m_InputHandler;
    Vector3 characterVelocity;
     float _gravity = 9.8f;

    private void Start()
    {
        m_Controller = GetComponent<CharacterController>();
        m_InputHandler = GetComponent<PlayerInputHandler>();
    }
    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector3 worldspaceMoveInput = transform.TransformVector(m_InputHandler.GetMoveInput());
        Vector3 targetVelocity = worldspaceMoveInput * moveSpeed;
        characterVelocity = Vector3.Lerp(characterVelocity, targetVelocity, 0.5f);
        characterVelocity.y -= _gravity;
        m_Controller.Move(new Vector3(characterVelocity.x * Time.deltaTime, characterVelocity.y, characterVelocity.z* Time.deltaTime));
    }
}
