using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class OnHoverChanges : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMP_Text currentTeamMember;

    [SerializeField]
    public Color hoverColor;

    [SerializeField]
    private UnityEngine.UI.Image image;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip song;

    [SerializeField]
    private TMP_Text[] teamMembers;

    private Color nonHoverColor;

    void Awake()
    {
        nonHoverColor = currentTeamMember.color;
        nonHoverColor.a = 1f;
        hoverColor.a = 1f;
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        currentTeamMember.color = hoverColor;
        StartCoroutine(FadeIn());
        image.sprite = sprite;
        audioSource.clip = song;
        audioSource.Play();

        for (int i = 0; i < teamMembers.Length; i++)
        {
            teamMembers[i].color = new Color(1, 1, 1, 0.02f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentTeamMember.color = nonHoverColor;
        StopAllCoroutines();
        image.color = Color.black;
        image.sprite = null;
        audioSource.Stop();
        audioSource.clip = null;

        for (int i = 0; i < teamMembers.Length; i++)
        {
            teamMembers[i].color = nonHoverColor;
        }
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1.5f)
        {
            image.color = new Color(Mathf.Lerp(0f, 1f, elapsedTime / 1.5f), Mathf.Lerp(0f, 1f, elapsedTime / 1.5f), Mathf.Lerp(0f, 1f, elapsedTime / 1.5f), 1f);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }


}

