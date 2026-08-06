using UnityEngine;
using TMPro;

public class ElevatorManager : MonoBehaviour
{
    public TMP_Text floorText;
    public TMP_Text messageText;
    public TMP_Text moveCountText;

    int currentFloor = 1;
    int minFloor = -2;
    int maxFloor = 10;

    string message = "1층입니다";

    int moveCount = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        moveCount++;

        floorText.text = "현재 층: " + currentFloor + "층";
        messageText.text = "상태" + message;
        moveCountText.text = "엘리베이터 이동 횟수: " + moveCount;


        if (currentFloor == 10)
        {
            message = "꼭대기";
        }
        if (currentFloor == 1)
        {
            message = "로비";
        }
    }

    public void MoveUp()
    {
        if (currentFloor < maxFloor)
        {
            currentFloor++;
            message = currentFloor + "층으로 이동했습니다.";
        }
        else
        {
            message = "최상층입니다.";
        }

        UpdateUI();
    }

    public void MoveDown()
    {
        if (currentFloor > minFloor)
        {
            currentFloor--;
            message = currentFloor +"층으로 이동했습니다.";
        }
        else
        {
            message = "최하층입니다.";
        }

        UpdateUI();
    }

    public void MoveToFirstFloor()
    {
        currentFloor = minFloor;
        message = "B2층으로 이동했습니다.";
        UpdateUI();
    }

    public void MoveToTopFloor()
    {
        currentFloor = maxFloor;
        message = "최상층으로 이동했습니다.";
        UpdateUI();
    }

    public void ResetElevator()
    {
        currentFloor = 1;
        message = "엘리베이터가 초기화되었습니다.";
        UpdateUI();
    }

}
