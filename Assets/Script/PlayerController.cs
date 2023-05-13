using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("|--- References ---|")]
    [Header("Component")]
    [SerializeField]
    private CharacterController _characterController;
    [Header("|--- Properties ---|")]
    [Header("Movement")]
    [SerializeField]
    private float m_moveSpeed;
    [Header("Movement")]
    [SerializeField]
    private float m_cameraSens = 50f;
    private float m_gravityValue = Physics.gravity.y;


    public static bool m_canMove = true;

    Camera m_mainCamera;
    private float xRotation;
    private float yRotation;

    private void Awake()
    {
        m_mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) Escape();



        if(m_canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * m_cameraSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * m_cameraSens * Time.deltaTime;

            xRotation += mouseY;
            xRotation = Mathf.Clamp(xRotation ,- 90,90);

            m_mainCamera.transform.rotation = Quaternion.Euler(xRotation,0,0);
            _characterController.transform.Rotate(Vector3.up * mouseY);
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
    }
}
