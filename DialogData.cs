
using UnityEngine;
[System.Serializable]
public class Speaker 
{   
    public string speakerName;
    public Sprite portrait;
}

[System.Serializable]
public class Ment
{
    public int speakerNum;

    public string text; 
} 

[System.Serializable]
public class Dialog
{
    public Sprite[] Bg;
    public Speaker[] speakers;

    public Ment[] dialog;
}

[CreateAssetMenu(fileName ="Dialog",menuName ="Scriptable/Dialog",order = 0)]

public class DialogData : ScriptableObject
{

   public Dialog[] sceneDialogs;
}