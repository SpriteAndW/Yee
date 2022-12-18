using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public float keyspeed, mousespeed;
    float sx = 0, sy = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//lockState将鼠标锁定在屏幕中间
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * mousespeed;
        float y = Input.GetAxis("Mouse Y") * mousespeed;
        sx -= y;
        sy += x;
        sx = Mathf.Clamp(sx, -85, 85);
        transform.rotation = Quaternion.Euler(sx, sy, 0f);
        float jx = Input.GetAxis("Horizontal") * keyspeed, jz = Input.GetAxis("Vertical") * keyspeed;
        transform.position += transform.right * jx + transform.forward * jz;
    }
}
