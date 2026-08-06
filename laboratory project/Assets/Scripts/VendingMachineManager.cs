using UnityEngine;
using TMPro;

public class VendingMachineManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text colaText;
    public TMP_Text ciderText;
    public TMP_Text waterText;
    public TMP_Text messageText;

    int money = 0;

    int colaPrice = 1200;
    int ciderPrice = 1000;
    int waterPrice = 700;

    int colaStock = 3;
    int ciderStock = 3;
    int waterStock = 3;

    string message = "돈을 넣어주세요.";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }


    void UpdateUI()
    {
        moneyText.text = "현재 금액: " + money + "원";
        colaText.text = "콜라: " + colaPrice + "원 / 재고: " + colaStock;
        ciderText.text = "사이다: " + ciderPrice + "원 / 재고: " + ciderStock;
        waterText.text = "물: " + waterPrice + "원 / 재고: " + waterStock;
        messageText.text = message;
    }
    public void Insert500()
    {
        money += 500;
        message = "500원을 넣었습니다.";
        UpdateUI();
    }

    public void Insert1000()
    {
        money += 1000;
        message = "1000원을 넣었습니다.";
        UpdateUI();
    }

    public void BuyCola()
    {
        if (colaStock <= 0)
        {
            message = "콜라 재고가 없습니다.";
            UpdateUI();
            return;
        }

        if (money < colaPrice)
        {
            message = "돈이 부족합니다.";
            UpdateUI();
            return;
        }

        money -= colaPrice;
        colaStock--;

        message = "콜라를 구매했습니다.";
        UpdateUI();
    }

    public void  BuyCider()
    {
        if (ciderStock <= 0)
        {
            message = "사이다 재고가 없습니다";
            UpdateUI();
            return;
        }

        if (money < ciderPrice)
        {
            message = "돈이 부족합니다.";
            UpdateUI();
            return;
        }

        if (money >= ciderPrice)
        {
            money -= ciderPrice; // money = money - ciderPrice;
            ciderStock--;
            message = "사이다를 구매했습니다.";
            UpdateUI();
        }
    }

    public void BuyWater()
    {
        if (waterStock <= 0)
        {
            message = "물 재고가 없습니다";
            UpdateUI();
            return;
        }

        if (money < waterPrice)
        {
            message = "돈이 부족합니다.";
            UpdateUI();
            return;
        }

        if (money >= waterPrice)
        {
            money -= waterPrice; // money = money - waterPrice;
            waterStock--;
            message = "물을 구매했습니다.";
            UpdateUI();
        }
    }

    public void ReturnMoney()
    {
        if (money <= 0)
        {
            message = "반환할 돈이 없습니다.";
            UpdateUI();
            return;
        }

        message = money + "원을 반환했습니다.";
        money = 0;

        UpdateUI();
    }

    public void ResetMachine()
    {
        money = 0;

        colaPrice = 1200;
        ciderPrice = 1000;
        waterPrice = 700;

        colaStock = 3;
        ciderStock = 3;
        waterStock = 3;

        message = "자판기가 초기화되었습니다.";

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
