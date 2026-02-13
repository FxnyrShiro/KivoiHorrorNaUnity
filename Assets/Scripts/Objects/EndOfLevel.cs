using UnityEngine;
using UnityEngine.UIElements;

public class EndOfLevel : MonoBehaviour
{
    UIDocument interface_document;
    Button continue_button;
    private void Awake()
    {
        interface_document = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>();
        continue_button = interface_document.rootVisualElement.Q("continueButton") as Button;
        continue_button.SetEnabled(false);
        continue_button.visible = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Ты неудачник!!");
            Time.timeScale = 0;
            Label win_text = interface_document.rootVisualElement.Q("WINTEXT") as Label;
            win_text.text = "Ты неудачник";
            continue_button.visible=true;
            continue_button.SetEnabled(true);
        }
    }
}
