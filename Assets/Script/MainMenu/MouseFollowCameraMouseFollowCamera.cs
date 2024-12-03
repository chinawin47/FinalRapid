using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowCameraMouseFollowCamera : MonoBehaviour
{
    public float followSpeed = 5f; // ความเร็วในการตามเม้าส์
    public Vector2 limitX = new Vector2(-3f, 3f); // ขอบเขตการเคลื่อนที่ของกล้องในแนวแกน X
    public Vector2 limitY = new Vector2(-2f, 2f); // ขอบเขตการเคลื่อนที่ของกล้องในแนวแกน Y
    private Vector3 initialPosition; // ตำแหน่งเริ่มต้นของกล้อง

    void Start()
    {
        // ตรวจสอบว่า Main Camera ใช้ Orthographic
        if (Camera.main.orthographic == false)
        {
            Debug.LogError("Please set the Main Camera to Orthographic view for 2D.");
        }

        initialPosition = transform.position; // บันทึกตำแหน่งเริ่มต้นของกล้อง
    }

    void Update()
    {
        // รับตำแหน่งของเม้าส์ในหน้าจอ
        Vector3 mousePosition = Input.mousePosition;

        // แปลงจากตำแหน่งหน้าจอ (Screen) ไปยังตำแหน่งในโลก (World) 
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); // กำหนดระยะ Z ให้ตรงกับตำแหน่งกล้อง
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // คำนวณตำแหน่งเป้าหมาย (ไม่ให้เกินขอบเขตที่กำหนด)
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(worldPosition.x, limitX.x, limitX.y),
            Mathf.Clamp(worldPosition.y, limitY.x, limitY.y),
            initialPosition.z // รักษาตำแหน่ง Z คงที่
        );

        // ทำให้กล้องเคลื่อนไหวอย่างนุ่มนวลไปยังตำแหน่งที่ต้องการ
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }

}
