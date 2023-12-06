using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{ Bone, Tuna, Both, Unlock }

public class Collectable : MonoBehaviour
{
    // 1 dogFood 2 catFood 3 both 4 unlock
    public CollectableType cType;

    //public int type = 1;

    public int unlock = 1;
    public Sprite tuna;
    public Sprite bone;
    public Sprite unlockSprite;

    private UIController controller;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GameObject.Find("GameCanvas").GetComponent<UIController>();

        // set collectable image
        if (cType == CollectableType.Bone)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bone;
        }
        else if (cType == CollectableType.Tuna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tuna;
        }
        else if (cType == CollectableType.Unlock)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = unlockSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ved triggerenter chek type og for�g tyoe i UIcontroller med 1 og bed UIcontroller om at opdatere score text
        switch (cType)
        {
            case CollectableType.Bone:
                if (other.CompareTag("Dog"))
                {
                    GeneralSoundEffect.instance.PlaySoundEffect(DataManager.instance.collectClip, 1f); 
                    gameObject.GetComponent<ParticleSystem>().Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    Destroy(gameObject,.5f);
                    Debug.Log("Bone for dog");
                    controller.dogFood++;
                    controller.ShowFoodScoreUI();
                    controller.Updatescore();
                    
                }

                break;

            case CollectableType.Tuna:
                if (other.CompareTag("Cat"))
                {
                    Debug.Log("Tuna");
                    controller.ShowFoodScoreUI();
                    controller.catFood++;
                    controller.Updatescore();
                    GeneralSoundEffect.instance.PlaySoundEffect(DataManager.instance.collectClip, 1f);
                    gameObject.GetComponent<ParticleSystem>().Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    Destroy(gameObject, .5f);
                }

                break;

            case CollectableType.Both:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.ShowFoodScoreUI();
                    controller.catFood++;
                    controller.dogFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                    GeneralSoundEffect.instance.PlaySoundEffect(DataManager.instance.collectClip, 1f);
                    gameObject.GetComponent<ParticleSystem>().Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    Destroy(gameObject, .5f);
                }
                break;

            case CollectableType.Unlock:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.Unlocker(unlock);
                    Destroy(gameObject);
                }
                break;
        }
    }
}