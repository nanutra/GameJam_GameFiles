using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("|--- References ---|")]
    [Header("CustomEvents")]
    [SerializeField]
    CustomEvent m_onGamePauseEvent;
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
    [SerializeField]
    private float m_gravityScale = 1f;


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

            if(!_characterController.isGrounded)
            {
                dir += Vector3.up * m_gravityValue * Time.deltaTime;
            }
            _characterController.Move(dir);
            

        }

        if(transform.position.y < - 30)
        {
            transform.position = Vector3.up * 1f;
        }
    }

    void Escape()
    {
        //met en pause le jeu
        m_canMove = !m_canMove; 
        if(m_canMove)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
        DataHandler.IsGamePause = !DataHandler.IsGamePause;
        if (m_onGamePauseEvent)
            m_onGamePauseEvent.Raise();
    }

}
