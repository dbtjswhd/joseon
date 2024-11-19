using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;

        //cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // 마우스 입력 처리 (카메라 회전)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 카메라 회전 제한 (위/아래)
        
        if(cameraTransform != null){
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        transform.Rotate(Vector3.up * mouseX);

        // 이동 입력 처리
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        bool runInput = Input.GetKey(KeyCode.LeftShift);

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // 달리기 입력 처리
        float speed =  runInput ? runSpeed : moveSpeed;

        // 이동 실행
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        SceneMove();
    }

    void SceneMove()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Step1");
        }
    }
}
