using UnityEngine;
using TMPro;

public class FridgeManager : MonoBehaviour
{
    public TMP_Text temperatureText;
    public TMP_Text doorText;
    public TMP_Text foodStateText;
    public TMP_Text messageText;

    float fridgeTemperature = 4.0f;

    bool isDoorOpen = false;
    bool isFoodSpoiled = false;

    string message = "냉장고 정상";

    float doorOpenTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorOpen == true)
        {
            fridgeTemperature += Time.deltaTime * 0.5f;
            doorOpenTime += Time.deltaTime;
        }
        else
        {
            fridgeTemperature -= Time.deltaTime * 0.2f;
        }

        if (fridgeTemperature < 4.0f)
        {
            fridgeTemperature = 4.0f;
        }


        CheckFoodState();

        UpdateUI();

        // 문 상태에 따라 온도를 변화시킵니다.

        // 온도에 따라 음식 상태를 확인합니다.

        // UI를 갱신합니다.
    }

    void UpdateUI()
    {
        temperatureText.text = "냉장고 온도:" + fridgeTemperature.ToString("F1") + "°C";
        
        if (isDoorOpen == true)
        {
            doorText.text = "문 상태: 열림";
        }
        else
        {
            doorText.text = "문 상태: 닫힘";
        }

        if (isFoodSpoiled == true)
        {
            foodStateText.text = "음식 상태: 상함";
        }
        else
        {
            foodStateText.text = "음식 상태: 신선";
        }

        if (doorOpenTime >= 10.0f)
        {
            message = "문이 너무 오래 열려있습니다!";
        }

        messageText.text = "상태:" + message;
    }

    public void OpenDoor()
    {
        isDoorOpen = true;
        message = "문이 열렸습니다.";
        UpdateUI();
    }

    public void CloseDoor()
    {
        isDoorOpen = false;
        message = "문이 닫혔습니다.";
        doorOpenTime = 0.0f;
        UpdateUI();
    }

    public void ResetButton()
    {
        fridgeTemperature = 4.0f;

        isDoorOpen = false;
        isFoodSpoiled = false;
        message = "냉장고 정상";
        doorOpenTime = 0.0f;
        UpdateUI();
    }

    void CheckFoodState()
    {
        if (isFoodSpoiled == true)
        {
            message = "음식이 이미 상했습니다";
            return;
        }

        if (fridgeTemperature >= 15.0f)
        {
            isFoodSpoiled = true;
            message = "음식이 상했습니다";
        }
        else if (fridgeTemperature >= 10.0f)
        {
            message = "음식이 상할 위험이 있습니다";
        }
        else
        {
            message = "냉장고 정상";
        }
    }
}
