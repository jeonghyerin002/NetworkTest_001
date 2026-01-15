using UnityEngine;
using UnityEngine.UI;

public class CallbackButtonDemo : MonoBehaviour
{
    [Header("UI Button 연결")]
    public Button button;

    private void Awake()
    {
        if(button == null)
        {
            Debug.LogError("버튼이 연결되지 않았습니다.");
            return;
        }
        button.onClick.AddListener(OnClicked);
    }
    private void OnDestroy()
    {
        if(button != null)
            button.onClick.RemoveListener(OnClicked);
    }
    public void OnClicked()
    {
        Debug.Log("버튼이 눌렸습니다! (콜백 호출)");
    }
}
