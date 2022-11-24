using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public float mousesensitivitityX = 100f;
    public float mousesensitivitityY = 100f;
    public Transform player;
    [SerializeField] private float Xrotaion; 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivitityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivitityY * Time.deltaTime;

        Xrotaion -= mouseY;
        Xrotaion = Mathf.Clamp(Xrotaion, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrotaion, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
      
    }
}
