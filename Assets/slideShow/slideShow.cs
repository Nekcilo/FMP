using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class slideShow : MonoBehaviour
{
    Image imageComponent;
    float alpha;
    int listLen;
    int currentIndex;
    bool toBlack = false;
    bool toColour = false;

    public float fadeSpeed = 0.5f;
    public TMP_Text canvasText;

    //list of images
    public List<Sprite> images = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        listLen = images.Count;
        currentIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(toBlack)
        {
            float tempAlpha = imageComponent.color.a;
            alpha = tempAlpha - (0.01f * fadeSpeed);
            if(imageComponent.color.a <= 0.1f)
            {
                toBlack = false;
                toColour = true;

                Transition(currentIndex);
            }
            else
            {
                //imageComponent.color.a = alpha;
                imageComponent.color = new Color(1f, 1f, 1f, alpha);
            }
        }

        if(toColour)
        {
            float tempAlpha = imageComponent.color.a;
            alpha = tempAlpha + (0.01f * fadeSpeed);
            if(imageComponent.color.a >= 1)
            {
                toBlack = false;
                toColour = false;
            }
            else
            {
                imageComponent.color = new Color(1f, 1f, 1f, alpha);
            }
        }


        if(Input.GetKeyDown("right") && !toBlack && !toColour)
        {
            if(currentIndex >= listLen - 1)
            {
                currentIndex = 0;
                toBlack = true;
            }
            else
            {
                currentIndex++;
                toBlack = true;
            }
        }

        if(Input.GetKeyDown("left") && !toBlack && !toColour)
        {
            if(currentIndex <= 0)
            {
                currentIndex = listLen - 1;
                toBlack = true;
            }
            else
            {
                currentIndex--;
                toBlack = true;
            }
        }
        canvasText.text = (currentIndex+1).ToString() + "/" + listLen.ToString();
    }

    void Transition(int imageId)
    {
        imageComponent.sprite = images[imageId];
    }
}
