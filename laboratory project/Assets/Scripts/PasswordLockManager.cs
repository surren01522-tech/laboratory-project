using UnityEngine;
using TMPro;

public class PasswordLockManager : MonoBehaviour
{
    public TMP_Text inputText;
    public TMP_Text lockStateText;
    public TMP_Text messageText;

    string inputPassword = "";
    string correctPassword = "1234";

    bool isUnlocked = false;

    string message = "비밀번호를 입력하세요.";

    int failCount = 0;

    bool isBlocked = false;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (inputPassword.Length > 4)
        {
            message = "비밀번호는 4자리까지만 입력할 수 있습니다.";
            UpdateUI();
            return;
        }
        inputText.text = "입력값: " + new string('*', inputPassword.Length);

        if (isUnlocked == true)
        {
            lockStateText.text = "잠금 상태: 해제";
        }
        else
        {
            lockStateText.text = "잠금 상태: 잠김";
        }

        messageText.text = "상태: " + message;
    }

    public void InputOne()
    {
        if (isUnlocked == true)
        {
            message = "이미 잠금이 해제되었습니다";
            UpdateUI();
            return;
        }
        inputPassword += "1";
        message = "1 입력";
        UpdateUI();
    }

    public void InputTwo()
    {
        if (isUnlocked == true)
        {
            message = "이미 잠금이 해제되었습니다";
            UpdateUI();
            return;
        }
        inputPassword += "2";
        message = "2 입력";
        UpdateUI();
    }

    public void InputThree()
    {
        if (isUnlocked == true)
        {
            message = "이미 잠금이 해제되었습니다";
            UpdateUI();
            return;
        }
        inputPassword += "3";
        message = "3 입력";
        UpdateUI();
    }

    public void InputFour()
    {
        if (isUnlocked == true)
        {
            message = "이미 잠금이 해제되었습니다";
            UpdateUI();
            return;
        }
        inputPassword += "4";
        message = "4 입력";
        UpdateUI();
    }

    public void CheckPassword()
    {
        if (!isUnlocked == false)
        {
            message = "확인할 수 없습니다";
            UpdateUI();
            return;
        }
        if (inputPassword == correctPassword)
        {
            isUnlocked = true;
            message = "비밀번호 일치합니다";
        }
        else
        {
            message = "비밀번호가 일치하지않습니다";
        }
        UpdateUI();
    }

    public void ClearInput()
    {
        inputPassword = "";
        message = "입력값이 초기화 되었습니다";
        UpdateUI();
    }

    public void ResetLock()
    {
        inputPassword = "";
        isUnlocked = false;
        message = "리셋되었습니다";
        UpdateUI();
    }
    public void FailCount()
    {
        if (failCount >= 3)
        {
            isBlocked = true;
            message = "비밀번호를 3번 틀려 잠금장치가 차단되었습니다.";
            return;
        }

        failCount++;
        message = "실패했습니다";
        UpdateUI() ;
    }

}