using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    GameObject player;
    InputAction rotateAction;

    [SerializeField]
    private int sensivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateAction = InputSystem.actions.FindAction("Look");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rotateValues = rotateAction.ReadValue<Vector2>();
        player.transform.Rotate(Vector3.up * rotateValues.x);
    }
}
