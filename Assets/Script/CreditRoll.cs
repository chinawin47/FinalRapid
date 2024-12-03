using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    [SerializeField] private RectTransform[] elementsToMove; // อ้างอิง RectTransform ของ Logo และ Text
    [SerializeField] private float speed = 50f;             // ความเร็วในการเลื่อน
    [SerializeField] private float endPositionY = 1000f;    // ตำแหน่ง Y ที่สิ้นสุด

    private void Start()
    {
        StartCoroutine(RollCredits());
    }

    private IEnumerator RollCredits()
    {
        // Loop ทุก RectTransform ที่อยู่ใน elementsToMove
        while (true)
        {
            bool hasReachedEnd = true;

            foreach (var element in elementsToMove)
            {
                // ถ้าตำแหน่งยังไม่ถึงจุดสิ้นสุด
                if (element.anchoredPosition.y < endPositionY)
                {
                    element.anchoredPosition += new Vector2(0, speed * Time.deltaTime);
                    hasReachedEnd = false;
                }
            }

            if (hasReachedEnd)
            {
                break;
            }

            yield return null;
        }
    }
}


