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
    private float mouseSensitivity = 50f;
    private float m_gravityValue = Physics.gravity.y;
    [SerializeField]
    private float m_gravityScale = 1f;
    public static bool m_canMove = true;
    float yaw, pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) Escape();

      
    if (m_canMove)
        {

            #region NewCamera

            yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

            // Clamp pitch between lookAngle
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            transform.localEulerAngles = new Vector3(0, yaw, 0);
            m_mainCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

            #endregion
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");


            Vector3 dir = (transform.right * hor + transform.forward * ver) * m_moveSpeed * Time.deltaTime;

            if(!_characterController.isGrounded)
            {
                dir += Vector3.up * m_gravityValue * Time.deltaTime;
            }
            if(_characterController)
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
