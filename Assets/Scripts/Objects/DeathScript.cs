using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DeathScript : MonoBehaviour
{
    UIDocument interface_document;
    Label win_text;
    Button important_button;
    private void Awake()
    {
        important_button = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>().rootVisualElement.Q("continueButton") as Button;
        interface_document = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            important_button.SetEnabled(true);
            important_button.visible = true;
            important_button.RegisterCallback<ClickEvent>(youDied);
            win_text = interface_document.rootVisualElement.Q("WINTEXT") as Label;
            win_text.text = "Ты супер неудачник";
            Time.timeScale = 0;
        }
    }
    void youDied(ClickEvent ev)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
