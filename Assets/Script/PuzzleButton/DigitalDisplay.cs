using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{

    [SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;

    private string codeSequence;

    void Start()
    {
        codeSequence = "";
        for (int i = 0; i <= characters.Length -1; i++) 
        {
            characters[i].sprite = digits[10];
        }
        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if(codeSequence.Length < 4)
        {
            switch (digitEntered) 
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequenece(0);
                    break;
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequenece(1);
                    break;
                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequenece(2);
                    break;
                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequenece(3);
                    break;
                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequenece(4);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequenece(5);
                    break;
                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequenece(6);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequenece(7);
                    break;
                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequenece(8);
                    break;
                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequenece(9);
                    break;
            }
        }
        switch (digitEntered)
        {
            case "Star":
                ResetDisplay();
                break;
            case "Hash":
                if(codeSequence.Length > 0)
                {
                    CheckResults();
                }
                break;
        }
    }

    private void DisplayCodeSequenece(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break; 
           
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
                
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }
    }

    public GameObject objectToDelete; // ลาก Object ที่ต้องการลบมาใส่ใน Inspector

    private void CheckResults()
    {
        if (codeSequence == "6820")
        {
            Debug.Log("Correct!");

            // ย้ายไปยัง Scene ถ้าคำตอบถูกต้อง
            SceneManager.LoadScene("InDrawerScene"); // เปลี่ยน "NextSceneName" เป็นชื่อ Scene ที่ต้องการโหลด

        }
        else
        {
            Debug.Log("Wrong!");
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        for(int i = 0; i <= characters.Length - 1; i++) 
        {
            characters[i].sprite = digits[10];
        }
        codeSequence = "";
    }

    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }

}
