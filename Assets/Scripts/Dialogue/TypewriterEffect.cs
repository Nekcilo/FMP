using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text _textBox;

    public float _wordDelay = 0f;
    bool _canWord = true;
    bool _interrupt = false;

    public bool done = true;

    public List<string> paragraphs = new List<string>();

    IEnumerator StartTyping(int paragraph)
    {
        if(_interrupt == true)
        {
            _canWord = true;
            yield return null;
        }


        done = false;
        foreach(char character in paragraphs[paragraph])
        {
            _canWord = false;
            string tempText = _textBox.text + char.ToString(character);
            _textBox.text = tempText;
            yield return new WaitForSeconds(_wordDelay);
        }
        done = true;
    }

    void InstantWrite(int paragraph)
    {
        if(!_canWord)
        {
            // If currently typing, wait until finished typing before performing instant write.
            _interrupt = true;
            StartCoroutine(WaitForTyping(paragraph));
        }
        else
        {
            // If not currently typing, perform instant write.
            _textBox.text = paragraphs[paragraph];
        }
    }

    IEnumerator WaitForTyping(int paragraph)
    {
        // Wait until _canWord is true (i.e. typing is finished) before performing instant write.
        while(!_canWord)
        {
            yield return null;
        }
        
        // Perform instant write.
        StopCoroutine("StartTyping");
        _textBox.text = paragraphs[paragraph];
    }


    void WordDelay()
    {
        //allows firing after the set delay on invoke
        _canWord = true;
    }

    public void TriggerTyping(int paragraph)
    {
        if(done)
        {
            StartCoroutine(StartTyping(paragraph));
        }
        else
        {
            InstantWrite(paragraph);
        }
    }
}