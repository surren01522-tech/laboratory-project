using UnityEngine;
using TMPro;

public class AirConditionerManager : MonoBehaviour
{
    public TMP_Text roomTempText;
    public TMP_Text targetTempText;
    public TMP_Text powerText;
    public TMP_Text messageText;

    float roomTemperature = 30.0f;
    float targetTemperature = 24.0f;

    bool isAirConditionerOn = false;

    string message = "에어컨이 꺼져 있습니다.";

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (isAirConditionerOn == true)
        {
            roomTemperature--;
        }
        if (isAirConditionerOn == false)
        {
            roomTemperature++;
        }
        if (roomTemperature < 16.0f)
        {
            roomTemperature = 16.0f;
        }
        if (roomTemperature > 35.0f)
        {
            roomTemperature = 35.0f;
        }
        if (roomTemperature <= targetTemperature)
        {
            isAirConditionerOn = false;
            message = "목표 온도에 도달하여 에어컨이 꺼졌습니다.";
        }
        CheckTemperatureState();
        UpdateUI();
        // 에어컨이 켜져 있는지 확인

        // 켜져 있으면 현재 온도 감소

        // 꺼져 있으면 현재 온도 증가

        // 상태 메시지 확인

        // UI 갱신
    }

    void UpdateUI()
    {
        roomTempText.text = "현재 온도: " + roomTemperature.ToString("F1") + "도";
        targetTempText.text = "목표 온도: " + targetTemperature.ToString("F1") + "도";

        if (isAirConditionerOn == true)
        {
            powerText.text = "에어컨 상태: 켜짐";
        }
        else
        {
            powerText.text = "에어컨 상태: 꺼짐";
        }

        messageText.text = "상태: " + message;
    }

    public void PowerOn()
    {
        isAirConditionerOn = true;
        message = "에어컨 전원 켜기";
        UpdateUI();
        // isAirConditionerOn을 true로 변경

        // message 변경

        // UI 갱신
    }

    public void PowerOff()
    {
        isAirConditionerOn = false;
        message = "에어컨 전원 끄기";
        UpdateUI();
    }

    public void TargetUp()
    {
        if (targetTemperature > 30.0f)
        {
            targetTemperature = 30.0f;
            UpdateUI();
            return;
        }
        targetTemperature++;
        message = "온도가 증가하였습니다";
        UpdateUI();
        // targetTemperature 증가

        // message 변경

        // UI 갱신
    }
    public void TargetDown()
    {
        if (targetTemperature < 18.0f)
        {
            targetTemperature = 18.0f;
            UpdateUI();
            return;
            
        }
        targetTemperature--;
        message = "온도가 감소하였습니다";
        UpdateUI();
        // targetTemperature 감소

        // message 변경

        // UI 갱신
    }
    void CheckTemperatureState()
    {
        if (targetTemperature >=  30)
        {
            message = "너무 더워요 쏘 핫";
        }
        if ( targetTemperature < roomTemperature && isAirConditionerOn == true)
        {
            message = "냉방중입니다 돈 나가는 중";
        }
        if (targetTemperature > roomTemperature)
        {
            message = "너무 추워 아추추";
        }
        else
        {
            message = "적정 온도 예염";
        }
        // 현재 온도가 30도 이상이면 덥다는 메시지

        // 현재 온도가 목표 온도보다 높고 에어컨이 켜져 있으면 냉방 중 메시지

        // 현재 온도가 목표 온도보다 낮으면 너무 춥다는 메시지

        // 그 외에는 적정 온도 메시지
    }

    public void ResetAirConditioner()
    {
        roomTemperature = 0;
        targetTemperature = 0;
        isAirConditionerOn = false;
        message = "초기화 되써염";
        UpdateUI();
        // 현재 온도 초기화

        // 목표 온도 초기화

        // 에어컨 상태 초기화

        // message 변경

        // UI 갱신
    }
}
