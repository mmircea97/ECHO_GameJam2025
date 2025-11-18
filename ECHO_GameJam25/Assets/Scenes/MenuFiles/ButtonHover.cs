using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class PlayButtonHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Button button;
    
    public Sprite regularSprite;
    public Sprite onHoverSprite;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Button>().image.sprite = onHoverSprite;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Button>().image.sprite = regularSprite;
    }
}
