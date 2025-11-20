using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    private bool isWalking;
    private void Update()
    {
       Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y) * Time.deltaTime * moveSpeed;
        transform.position += moveDir;

        isWalking = moveDir != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotationSpeed);
        Debug.Log($"Input Vector: {inputVector}");

    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
