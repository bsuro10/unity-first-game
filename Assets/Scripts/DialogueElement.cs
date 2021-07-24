using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueElement
{
    public string name;

    public Color32 nameColor;

    [TextArea(3, 10)]
    public string sentence;

    public Color32 sentenceColor;

    public DialogueElement(string name, Color32 nameColor, string sentence, Color32 sentenceColor)
    {
        this.name = name;
        this.nameColor = nameColor;
        this.sentence = sentence;
        this.sentenceColor = sentenceColor;
    }
}
