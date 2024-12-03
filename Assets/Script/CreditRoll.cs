using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    [SerializeField] private RectTransform[] elementsToMove; // ��ҧ�ԧ RectTransform �ͧ Logo ��� Text
    [SerializeField] private float speed = 50f;             // ��������㹡������͹
    [SerializeField] private float endPositionY = 1000f;    // ���˹� Y �������ش

    private void Start()
    {
        StartCoroutine(RollCredits());
    }

    private IEnumerator RollCredits()
    {
        // Loop �ء RectTransform �������� elementsToMove
        while (true)
        {
            bool hasReachedEnd = true;

            foreach (var element in elementsToMove)
            {
                // ��ҵ��˹��ѧ���֧�ش����ش
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


