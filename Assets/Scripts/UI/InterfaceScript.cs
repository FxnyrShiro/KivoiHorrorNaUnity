using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InterfaceScript : MonoBehaviour
{
    Label timer;
    Button next_level;
    void Awake()
    {
        timer = GetComponent<UIDocument>().rootVisualElement.Q("Timer") as Label;
        next_level = GetComponent<UIDocument>().rootVisualElement.Q("continueButton") as Button;
        //next_level.RegisterCallback<ClickEvent>(nextLevel);
    }

    void Update()
    {
        timer.text = Mathf.FloorToInt(Time.fixedTime).ToString();

    }
    private void OnDisable()
    {
        //next_level.UnregisterCallback<ClickEvent>(nextLevel);
    }
    void nextLevel(ClickEvent evt)
    {
        //Debug.Log("Button is pressed");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
