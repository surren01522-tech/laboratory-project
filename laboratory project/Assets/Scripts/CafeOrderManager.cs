using UnityEngine;
using TMPro;

public class CafeOrderManager : MonoBehaviour
{
    public TMP_Text orderText;
    public TMP_Text priceText;
    public TMP_Text messageText;
    public TMP_Text totalCountText;

    int americanoCount = 0;
    int latteCount = 0;
    int CakeCount = 0;

    int americanoprice = 2000;
    int altterPrice = 3500;
    int CakePrice = 4500;

    int totalPrice = 0;
    int totalCount = 0;

    bool isPaid = false;

    string message = "주문을 선택하세요.";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        orderText.text = "아메리카노" + americanoCount +"잔, 라떼" + latteCount + "잔, 케이크" + CakeCount + "개";
        priceText.text = "총 가격: " + totalPrice + "원";
        messageText.text = "상태: " + message;
    }

    public void AddAmericano()
    {
        if (isPaid == true)
        {
            message = "결제가 완료되었습니다. 주문을 추가할 수 없습니다.";
            UpdateUI();
            return;
        }

        americanoCount++;
        totalPrice += americanoprice;
        message = "아메리카노를 추가했습니다.";
        UpdateUI();
    }

    public void AddLatte()
    {
        if (isPaid == true)
        {
            message = "결제가 완료되었습니다. 주문을 추가할 수 없습니다.";
            UpdateUI();
            return;
        }
        latteCount++;
        totalPrice += altterPrice;
        message = "라떼를 추가했습니다.";
        UpdateUI();
    }

    public void AddCake()
    {
        if (isPaid == true)
        {
            message = "결제가 완료되었습니다. 주문을 추가할 수 없습니다.";
            UpdateUI();
            return;
        }
        CakeCount++;
        totalPrice += CakePrice;
        message = "케이크를 추가했습니다.";
        UpdateUI();
    }

    public void Pay()
    {
        if (totalPrice == 0)
        {
            message = "주문이 없습니다. 결제할 수 없습니다.";
            UpdateUI();
            return;
        }
        if (isPaid== true)
        {
            message = "이미 결제가 완료되었습니다.";
            UpdateUI();
            return;
        }
        if (totalPrice > 10000)
        {
            isPaid = true;
            totalPrice -= 1000;
            message = "1000원 할인 후 결제 완료";
            UpdateUI();
        }

        isPaid = true;
        message = totalPrice + "원 결제 완료";
        UpdateUI();
    }

    public void CancelOrder()
    {
        if ( isPaid == true)
        {
            message = "결제가 완료되었습니다. 주문을 취소할 수 없습니다.";
            UpdateUI();
            return;
        }

        isPaid = false;

        americanoCount = 0;
        latteCount = 0;
        totalPrice = 0;

        message = "주문이 취소되었습니다.";
        UpdateUI();
    }

    public void ResetOrder()
    {
        isPaid = false;
        americanoCount = 0;
        latteCount = 0;
        totalPrice = 0;
        message = "주문이 초기화되었습니다.";
        UpdateUI();
    }

    public void AddTotalCount()
    {
        totalCount++;
        message = "총 주문 횟수: " + totalCount + "회";
        UpdateUI();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
