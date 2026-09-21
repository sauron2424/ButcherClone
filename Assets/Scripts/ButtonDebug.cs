using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDebug : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        Button b = GetComponent<Button>();
        if (b != null)
            b.onClick.AddListener(() => Debug.Log("ONCLICK —–¿¡Œ“¿À Û " + gameObject.name));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(" À»  ƒŒÿ®À ƒŒ: " + gameObject.name);
    }
}