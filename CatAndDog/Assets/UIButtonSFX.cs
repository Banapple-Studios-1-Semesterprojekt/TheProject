using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private ButtonSoundManager soundManager;

    private void Start()
    {
        soundManager = FindAnyObjectByType<ButtonSoundManager>();
        if(soundManager == null)
        {
            Debug.LogError("No ButtonSoundManager found in the scene!");
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        soundManager.PlaySoundEffect(soundManager.mouseOverClip);
    }
    public void OnPointerExit(PointerEventData data)
    {
        soundManager.PlaySoundEffect(soundManager.mouseExitClip);
    }
    public void OnPointerDown(PointerEventData data)
    {
        soundManager.PlaySoundEffect(soundManager.mouseDownClip);
    }
}
