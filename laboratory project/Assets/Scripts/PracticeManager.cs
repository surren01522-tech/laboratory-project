using UnityEngine;
using UnityEngine.InputSystem;

public class PracticeManager : MonoBehaviour
{
    public int score = 100;
    public int hp = 10;
    float speed = 2.5f;
    bool isGameOver = false;
    string playerName = "Slime";

    public SpriteRenderer spriteRenderer;
    public Transform playerTransform;

    void Start()
    {
        Debug.Log("플레이어 이름: " + playerName);
        Debug.Log("점수: " + score.ToString());
        Debug.Log("체력: " + hp.ToString());
        Debug.Log("속도: " + speed.ToString());
        Debug.Log("게임오버 상태: " + isGameOver.ToString());

        ChangeColorRed();
    }

    void ChangeColorRed()
    {
        spriteRenderer.color = Color.red;
    }

    void UpdateColor()
    {
        if (hp <= 0)
        {
            spriteRenderer.color = Color.pink;
        }
        else if (hp == 1)
        {
            spriteRenderer.color = Color.blue;
        }
        else if (hp == 2)
        {
            spriteRenderer.color = Color.purple;
        }
        else
        {
            spriteRenderer.color = Color.skyBlue;
        }
    }

    void Damage()
    {
        if (isGameOver == true)
        {
            Debug.Log("이미 게임오버 상태입니다.");
            return;
        }

        hp--;

        Debug.Log("데미지를 받았습니다.");

        if (hp <= 0)
        {
            isGameOver = true;
            Debug.Log("게임오버 상태가 되었습니다.");
        }
    }

    void UpdateScale()
    {
        float size = 1.0f + score * 0.3f;
        playerTransform.localScale = new Vector3(size, size, 1);
    }

    void AddScore()
    {
        if (isGameOver == true)
        {
            Debug.Log("이미 게임오버 상태입니다.");
            return;
        }

        score+= 5;
    }

    //int score = 100;
    //int hp = 10;
    //float speed = 2.5f;
    //bool isGameOver = true;
    //string playerName = "Slime";

    //void Start()
    //{
    //    Debug.Log("점수:" + 200);
    //    Debug.Log("체력:" + 20);
    //    Debug.Log("스피드:" + 5f);
    //    Debug.Log("게임오버상태:" + "실패");
    //    Debug.Log("플레이어 이름:" + 200);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Damage();
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            AddScore();
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            Heal();
        }

        UpdateColor();
        UpdateScale();
    }

    void Heal()
    {
        if (isGameOver == true)
        {
            Debug.Log("게임오바 상태라 회복할 수 없습니다.");
            return;
        }
        if (hp >= 5)
        {
            Debug.Log("체력이 가득 차서 회복할 수 없습니다.");
            return;
        }

        hp++;
        Debug.Log("체력 회복");
    }

}
