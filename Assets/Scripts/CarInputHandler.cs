using UnityEngine;
using UnityEngine.InputSystem;

public class CarInputHandler : MonoBehaviour
{
    public int playerNumber = 1;
    private TopDownController topDownCarController;

    private PlayerInput playerInput;
    private Vector2 inputVector;

    void Awake()
    {
        topDownCarController = GetComponent<TopDownController>();
        playerInput = GetComponent<PlayerInput>();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        topDownCarController.SetInputVector(inputVector);
    }
}