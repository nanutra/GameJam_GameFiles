using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("|--- References ---|")]
    [Header("Component")]
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    Camera m_mainCamera;

    [Header("|--- Properties ---|")]
    [Header("Movement")]
    [SerializeField]
    private float m_moveSpeed;
    [Header("Movement")]
    [SerializeField]
    private float m_cameraSens = 50f;
    private float m_gravityValue = Physics.gravity.y;


    public static bool m_canMove = true;

    Vector2 m_mouseMouvement;
    private float xRotation;
    private float yRotation;
    float xrot = 0, yrot = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) Escape();



        if(m_canMove)
        {
            #region OldCamera
            /*
            float mouseX = Input.GetAxis("Mouse X") * m_cameraSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * m_cameraSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation ,- 90,90);
     
            yRotation += mouseX;

            transform.rotation = Quaternion.Euler(Vector3.up * yRotation);
            m_mainCamera.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + xRotation * Vector3.right);
            /**/
            #endregion

            #region NewCamera
            m_mouseMouvement = Mouse.current.delta.ReadValue();
            Debug.Log(m_mouseMouvement);
            xrot = m_mouseMouvement.y * Time.deltaTime * m_cameraSens;
            yrot = m_mouseMouvement.x * Time.deltaTime * m_cameraSens;
            xRotation -= xrot;
            yRotation += yrot;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.rotation = Quaternion.Euler(Vector3.up * yRotation);
            m_mainCamera.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + xRotation * Vector3.right);

            #endregion
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            Vector3 dir = (transform.right * hor + transform.forward * ver) * m_moveSpeed * Time.deltaTime;
            _characterController.Move(dir);
        }
    }

    void Escape()
    {
        //met en pause le jeu
        Debug.Log("MetLeJeuEnPause");
        m_canMove = false; 
        Cursor.lockState = CursorLockMode.Locked;

    }
}
