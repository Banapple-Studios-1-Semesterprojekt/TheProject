using UnityEngine;

public class Collecterbels : MonoBehaviour
{
    // 1 dogFood 2 catFood 3 both 4 unlock
    public int type = 1;

    public int unlock = 1;
    public Sprite tuna;
    public Sprite bone;

    private UIController controller;

    // Start is called before the first frame update
    private void Start()
    {
        // set collecterbel image
        if (type == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bone;
        }
        else if (type == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tuna;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ved triggerenter chek type og for�g tyoe i UIcontroller med 1 og bed UIcontroller om at opdatere score text
        controller = GameObject.Find("Canvas").GetComponent<UIController>();
        switch (type)
        {
            case 1:
                if (other.CompareTag("Dog"))
                {
                    controller.dogFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }

                break;

            case 2:
                if (other.CompareTag("Cat"))
                {
                    controller.catFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }

                break;

            case 3:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.catFood++;
                    controller.dogFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }
                break;

            case 4:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.Unlocker(unlock);
                    Destroy(gameObject);
                }
                break;
        }
    }
}