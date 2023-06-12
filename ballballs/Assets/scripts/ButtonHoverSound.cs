using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private AudioSource audioSourceHover;
    [SerializeField]
    private AudioSource audioSourceClick;


    private void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSourceHover.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSourceClick.Play();

    }
}