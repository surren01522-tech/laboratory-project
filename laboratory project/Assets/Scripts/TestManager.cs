using UnityEngine;

public class TestManager : MonoBehaviour
{
    public PracticeManager practiceManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(practiceManager.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
