using UnityEngine;

public class InteractionController: MonoBehaviour
{
    public TypewriterEffect dialogueBox;
    public int paragraphIDStart;
    public int paragraphIDEnd;

    int currentID;
    bool triggered = false;

    public void Trigger()
    {
        if(!triggered)
        {
            if(dialogueBox.paragraphs.Count >= paragraphIDStart)
            {
                currentID = paragraphIDStart;
                dialogueBox.TriggerTyping(paragraphIDStart);
                triggered = true;
            }
            else
            {
                Debug.Log("Trying to play a paragraph id that is too large or too small");
            }
        }
        else
        {
            if(dialogueBox.done)
            {
                currentID++;
                if(currentID > paragraphIDEnd){return;}
                if(dialogueBox.paragraphs.Count >= currentID)
                {
                    dialogueBox.TriggerTyping(currentID);
                }
                else
                {
                    Debug.Log("Trying to play a paragraph id that is too large or too small");
                }
            }
            else
            {
                dialogueBox.TriggerTyping(currentID);
            }
        }
    }
}