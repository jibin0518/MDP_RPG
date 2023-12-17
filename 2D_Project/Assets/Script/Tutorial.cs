using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text txt;
    public GameObject player;
    public GameObject tutorial_Panel;
    public GameObject tutorial_Play_Panel;
    public Image a;
    public Image d;
    public Image space;
    public Image e;
    public Image mouseleft;
    public Image shift;
    public GameObject ground;
    public GameObject tutorial_Detail_Panel;

    public Text detailtxt;
    public Text ready;
    bool readystart;

    bool ainput;
    bool dinput;
    bool spaceinput;
    bool einput;
    bool mouseinput;
    bool shiftinput;

    bool enterinput;

    bool shiftor;
    bool etor;
    bool firetor;

    void Start()
    {
        txt.text = "ȯ���մϴ�\n";
        Invoke("NextTxt1", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        AKey();
        DKey();
        EKey();
        Space();
        Shift();
        MouseLeft();

        if (ainput && dinput && einput && spaceinput && mouseinput && shiftinput && !readystart)
        {
            ready.text = "�غ� �Ǽ̴ٸ� Enter�� �����ּ���\n";

            if (Input.GetKeyDown(KeyCode.Return))
            {
                enterinput = true;
                EnterGame();                
            }
            else if(!enterinput)
            {
                Invoke("EndTutorial", 7);
            }
            
        }
    }

    void EndTutorial()
    {
        readystart = true;
        ready.text = "";
        ready.text = "��� ����� �غ� ���δ� �߿����� �ʽ��ϴ�\n";

        Invoke("EnterGame", 3);
        ready.text += "�ӷ縦 �����մϴ�\n";
        ready.text += "��ǥ�� �����Ͻʽÿ�";
    }

    void AKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a.color = Color.gray;
            ainput = true;
        }
        else
        {
            a.color = Color.white;
        }
        
    }

    void DKey()
    {
        if (Input.GetKey(KeyCode.D))
        {
            d.color = Color.gray;
            dinput = true;
        }
        else
        {
            d.color = Color.white;
        }
    }

    void EKey()
    {
        if (Input.GetKey(KeyCode.E))
        {
            e.color = Color.gray;
            einput = true;
        }
        else
        {
            e.color = Color.white;
        }
    }

    void Space()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            space.color = Color.gray;
            spaceinput = true;
        }
        else
        {
            space.color = Color.white;
        }
    }

    void Shift()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shift.color = Color.gray;
            shiftinput = true;
        }
        else
        {
           shift.color = Color.white;
        }
    }

    void MouseLeft()
    {
        if (Input.GetMouseButton(0))
        {
            mouseleft.color = Color.gray;
            mouseinput=true;
        }
        else
        {
            mouseleft.color = Color.white;
        }
    }

    void NextTxt1()
    {
        txt.text += "����� ���� �̰����� ���ϰ� �� �����Դϴ� \n";
        Invoke("NextTxt2", 1.5f);
    }

    void NextTxt2()
    {
        txt.text += "����� ���� �̰��� ������ �����ϴ� ��\n";
        Invoke("NextTxt3", 1.5f);
    }

    void NextTxt3()
    {
        txt.text += "�׷� ����� ���ϴ�\n";
        Invoke("StartGame",1);
    }

    void EnterGame()
    {
        ground.SetActive(false);
    }

    void StartGame()
    {
        tutorial_Panel.SetActive(false);
        tutorial_Play_Panel.SetActive(true);
        player.SetActive(true);
        ready.text = "��� Ű�� ������ �غ� ��Ĩ�ϴ�\n";
        ready.text += "������ܿ� ü��(����)�� �Ѿ�(�Ķ�)�� �����ֽ��ϴ�";
        
    }
}
