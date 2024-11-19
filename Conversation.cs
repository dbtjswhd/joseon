using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    public DialogData dialogData;
    [SerializeField]
    private Dialog nowDialog;
    public Text nameT;
    public Text converT;

    Speaker nowSpeaker;
    string conver;

    public float dist = 0.1f;
    public float fadeOutDelay = 0;
    private float waitTime = 0;

    private int mentIndex = 0;
    private int typeNum;

    private bool onTyping = false;

    void Start()
    {
        StartDialog(0);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (onTyping)
            {
                SkipDialogue();
            }
            else
            {
                NextDialog();
            }
        }

        if (onTyping)
        {
            Typing();
        }
    }

    void StartDialog(int dialogNum)
    {
        nowDialog = dialogData.sceneDialogs[dialogNum];

        mentIndex = 0;

        Ment startMent = nowDialog.dialog[mentIndex];

        nowSpeaker = nowDialog.speakers[startMent.speakerNum];
        UpdateSpeaker(nowSpeaker);
        StartText(startMent.text); 
    }


    void UpdateSpeaker(Speaker speaker)
    {
        nameT.text = speaker.speakerName;
    }


    void StartText(string text)
    {
        conver = text;

        converT.text = conver[0].ToString();

        typeNum = 1;

        onTyping = true;
    }


    void Typing()
    {
        if (waitTime >= dist)
        {
            if (typeNum < conver.Length)
            {
                converT.text += conver[typeNum];
                typeNum++;
                waitTime = 0f;
            }
            else
            {
                onTyping = false;
            }
        }
        waitTime += Time.deltaTime;
    }

   
    void NextDialog()
    {
        mentIndex++;

        
        if (mentIndex >= nowDialog.dialog.Length)
        {
            nameT.text = "";
            onTyping = false;
            converT.text = "대화가 끝났습니다.";
            return;
        }

        
        Ment nextMent = nowDialog.dialog[mentIndex];
        nowSpeaker = nowDialog.speakers[nextMent.speakerNum];
        UpdateSpeaker(nowSpeaker);
        StartText(nextMent.text);
    }

    void SkipDialogue()
    {
        converT.text = conver;
        onTyping = false;
    }
}
