using UnityEngine;
using KModkit;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

public class KritHomework : MonoBehaviour
{
    public KMSelectable button1;
    public KMSelectable button2;
    public KMSelectable button3;
    public KMSelectable button4;
    public KMSelectable Pencil;

    public GameObject button1Obj;
    public GameObject button2Obj;
    public GameObject button3Obj;
    public GameObject button4Obj;
    public GameObject Grade;
    public GameObject AnswerText;

    public TextMesh Intro;
    public TextMesh question1;
    public TextMesh question2;
    public TextMesh question3;
    public TextMesh question4;

    public MeshRenderer Solve1;

    public Transform Hands;

    public MeshRenderer Clock;
    public MeshRenderer LED1;
    public MeshRenderer LED2;
    public MeshRenderer LED3;
    public MeshRenderer LED4;

    public KMSelectable[] ProcessTwitchCommand(string Command)
    {
        Command = Command.ToLowerInvariant().Trim();

        if (Command.Equals("start"))
        {
            return new[] { Pencil };
        }
        else if (Command.Equals("press button1"))
        {
            return new[] { button1 };
        }
        else if (Command.Equals("press button2"))
        {
            return new[] { button2 };
        }
        else if (Command.Equals("press button3"))
        {
            return new[] { button3 };
        }
        else if (Command.Equals("press button4"))
        {
            return new[] { button4 };
        }
        else if (Command.Equals("press 1"))
        {
            return new[] { button1 };
        }
        else if (Command.Equals("press 2"))
        {
            return new[] { button2 };
        }
        else if (Command.Equals("press 3"))
        {
            return new[] { button3 };
        }
        else if (Command.Equals("press 4"))
        {
            return new[] { button4 };
        }
        return null;
    }

    public KMAudio Audio;
    public KMAudio Bell;

    public KMBombInfo BombInfo;

    static int moduleIdCounter = 1;
    int ButtonAns;
    int moduleId;
    int Library;
    int correctIndex;
    int correctLibrary;
    int lessonStart = 0;

    private readonly string TwitchHelpMessage = "Type '!{0} start' to start the lesson. Type '!{0} press 1' (Or 'press button1') to answer with Answer 1.";


    bool Active = false;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        button1.OnInteract += Button1;
        button2.OnInteract += Button2;
        button3.OnInteract += Button3;
        button4.OnInteract += Button4;
        Pencil.OnInteract += StartLesson;
    }
    void Start()
    {
        question1.text = "Welcome to the";
        question2.text = "KLaNE school.";
        question3.text = "Class hasn't";
        question4.text = "started yet.";
    }
    void Init()
    {
        Bell.PlaySoundAtTransform("Bell", transform);
        lessonStart = 1;
        Intro.text = "Question:";
        question1.text = "";
        question2.text = "";
        question3.text = "";
        question4.text = "";
        Debug.LogFormat("[Module Homework #{0}] -----------------------------------------------------------------------------", moduleId);

        correctLibrary = 0;
        Library = 0;
        correctIndex = 0;
        ButtonAns = 0;

        correctLibrary = UnityEngine.Random.Range(0, 8);
        if (correctLibrary == 0)
        {
            Library = 1;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 1)
        {
            Library = 2;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 2)
        {
            Library = 3;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 3)
        {
            Library = 4;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 4)
        {
            Library = 5;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 5)
        {
            Library = 6;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 6)
        {
            Library = 7;
            correctIndex = UnityEngine.Random.Range(0, 4);
        }
        else if (correctLibrary == 7)
        {
            Library = 8;
            correctIndex = UnityEngine.Random.Range(0, 3);
        }
        //Who's On First
        if (correctIndex == 0 && Library == 1)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Who's on First'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: UHH", moduleId);
            question1.text = "Which of these is not";
            question2.text = "an answer in";
            question3.text = "Who's On First?";
            ButtonAns = 2;

        }
        //Memory
        else if (correctIndex == 1 && Library == 1)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Memory'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: 4", moduleId);
            question1.text = "Which label must";
            question2.text = "be pressed at stage";
            question3.text = "3 when the display";
            question4.text = "is 4 in Memory?";
            ButtonAns = 3;
        }
        //Morse Code
        else if (correctIndex == 2 && Library == 1)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Morse Code'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: 16", moduleId);
            question1.text = "How many inputs are";
            question2.text = "required to send 'Bombs'";
            question3.text = "in Morse Code?";
            ButtonAns = 1;
        }
        //Complex wires
        else if (correctIndex == 3 && Library == 1)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Complicated Wires'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: ONLY WITH 2+ BATTRIES", moduleId);
            question1.text = "Should a red wire with";
            question2.text = "a LED and a star be";
            question3.text = "cut in Complex Wires?";
            ButtonAns = 4;
        }
        //The Maze
        else if (correctIndex == 0 && Library == 2)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'The Maze'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: 9", moduleId);
            question1.text = "How many vanilla";
            question2.text = "mazes are there?";
            ButtonAns = 2;
        }
        //Passwords
        else if (correctIndex == 1 && Library == 2)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Passwords'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: M", moduleId);
            question1.text = "Which of the following";
            question2.text = "letters is NOT the start";
            question3.text = "of a vanilla Password?";
            ButtonAns = 3;
        }
        //Knob
        else if (correctIndex == 2 && Library == 2)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'The Knob'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: 12", moduleId);
            question1.text = "How many LED lights";
            question2.text = "are on a single";
            question3.text = "Knob Module?";
            ButtonAns = 2;
        }
        //Hexamaze
        else if (correctIndex == 3 && Library == 2)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Hexamaze'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: 19", moduleId);
            question1.text = "How many markings";
            question2.text = "are there in";
            question3.text = "the Hexamaze?";
            ButtonAns = 3;
        }
        //Swan
        else if (correctIndex == 0 && Library == 3)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'The Swan'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: 4, 8, 15, 16, 23, 42", moduleId);
            question1.text = "What are the numbers";
            question2.text = "in The Swan?";
            ButtonAns = 1;
        }
        //Poker
        else if (correctIndex == 1 && Library == 3)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Poker'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: 3 OF CLUBS", moduleId);
            question1.text = "Which of these cards";
            question2.text = "is not a starting";
            question3.text = "card in Poker?";
            ButtonAns = 4;
        }
        //Turn the keys
        else if (correctIndex == 2 && Library == 3)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Turn The Keys'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: TURN THE LEFT KEY", moduleId);
            question1.text = "Which of these actions";
            question2.text = "should not be done";
            question3.text = "before turning the";
            question4.text = "right key in TTKS?";
            ButtonAns = 1;
        }
        //Two Bits
        else if (correctIndex == 3 && Library == 3)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Two Bits'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: TV", moduleId);
            question1.text = "What character pair";
            question2.text = "belongs to the code";
            question3.text = "'51' in Two Bits?";
            ButtonAns = 2;
        }
        //Semaphore
        else if (correctIndex == 0 && Library == 4)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Semaphore'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: LETTERS", moduleId);
            question1.text = "What does Left Flag";
            question2.text = "North and Right Flag";
            question3.text = "East mean in";
            question4.text = "Semaphore?";
            ButtonAns = 2;
        }
        //Souvenir
        else if (correctIndex == 1 && Library == 4)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Souvenir'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: TANGRAMS", moduleId);
            question1.text = "Which of these modules";
            question2.text = "does not have to be";
            question3.text = "remembered for";
            question4.text = "Souvenir?";
            ButtonAns = 4;
        }
        //Random Number Generator
        else if (correctIndex == 2 && Library == 4)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Random Number Generator'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: 45", moduleId);
            question1.text = "If the serial has a";
            question2.text = "vowel and the last nr.";
            question3.text = "is odd, which of these";
            question4.text = "is allowed in RNG?";
            ButtonAns = 1;
        }
        //Answering Questions
        else if (correctIndex == 3 && Library == 4)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Answering Questions'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: IF YOU HAVE A STRIKE", moduleId);
            question1.text = "What does the";
            question2.text = "question 'Strikes?'";
            question3.text = "mean in Answering";
            question4.text = "Questions?";
            ButtonAns = 2;
        }
        //Button Masher
        else if (correctIndex == 0 && Library == 5)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Button Masher'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: 45", moduleId);
            question1.text = "What is the maximum";
            question2.text = "amount of button mashes";
            question3.text = "in Button Masher?";
            ButtonAns = 2;
        }
        //Hex To Decimal
        else if (correctIndex == 1 && Library == 5)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Hex To Decimal'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: 66", moduleId);
            question1.text = "What's the desired";
            question2.text = "number for the Hex code";
            question3.text = "'42' in Hex To";
            question4.text = "Decimal?";
            ButtonAns = 4;
        }
        //QR Code
        else if (correctIndex == 2 && Library == 5)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'QR Code'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: 8", moduleId);
            question1.text = "What's the most digits";
            question2.text = "in a QR code?";
            ButtonAns = 4;
        }
        //Astrology
        else if (correctIndex == 3 && Library == 5)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Astrology'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: A FOUR", moduleId);
            question1.text = "What symbol stands";
            question2.text = "for Jupiter in";
            question3.text = "Astrology?";
            ButtonAns = 3;
        }
        //Microcontroller
        else if (correctIndex == 0 && Library == 6)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Microcontroller'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: INDC", moduleId);
            question1.text = "Which of these is";
            question2.text = "not a controller";
            question3.text = "in Microcontroller?";
            ButtonAns = 1;
        }
        //Translated Modules
        else if (correctIndex == 1 && Library == 6)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Translated Modules'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: MEMORY", moduleId);
            question1.text = "Which of these is";
            question2.text = "not a Translated";
            question3.text = "Module? (Only from";
            question4.text = "Tharagon's mod)";
            ButtonAns = 4;
        }
        //Crazy Talk
        else if (correctIndex == 2 && Library == 6)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Crazy Talk'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: 8/1", moduleId);
            question1.text = "At what second marks";
            question2.text = "should the lever be";
            question3.text = "pulled for '.PERIOD'";
            question4.text = "in Crazy Talk?";
            ButtonAns = 3;
        }
        //Ice Cream
        else if (correctIndex == 3 && Library == 6)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Ice Cream'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: Cranberry Cream", moduleId);
            question1.text = "Which of these is";
            question2.text = "not a flavor of Ice";
            question3.text = "Cream in... Well...";
            question4.text = "Ice Cream?";
            ButtonAns = 4;
        }
        //Light Cycle
        else if (correctIndex == 0 && Library == 7)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Light Cycle'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: ORANGE", moduleId);
            question1.text = "What color isn't";
            question2.text = "present in";
            question3.text = "Light Cycle?";
            ButtonAns = 2;
        }

        //If any of these...
        if (ButtonAns > 0)
        {
            Debug.LogFormat("[Module Homework #{0}] Library: {1}, Index: {2}", moduleId, Library, correctIndex);
            Calculation();
        }
        //If none of these...
        else
        {
            Debug.LogFormat("[Module Homework #{0}] Attempting row 2...", moduleId);
            InitNext();
        }
    }

    void InitNext()
    {
        //Blackjack
        if (correctIndex == 1 && Library == 7)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Blackjack'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: A JACK OF DIAMONS", moduleId);
            question1.text = "Which of these";
            question2.text = "is not a starting";
            question3.text = "card in Blackjack?";
            ButtonAns = 1;
        }
        //British Slang
        else if (correctIndex == 2 && Library == 7)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'British Slang'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: PISH POSH", moduleId);
            question1.text = "Which of these";
            question2.text = "is not a";
            question3.text = "British Slang?";
            ButtonAns = 3;
        }
        //Periodic Table
        else if (correctIndex == 3 && Library == 7)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Periodic Table'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 4: Tr", moduleId);
            question1.text = "Which of these";
            question2.text = "is not a correct";
            question3.text = "Symbol in the";
            question4.text = "Periodic Table?";
            ButtonAns = 4;
        }
        //T-words
        else if (correctIndex == 0 && Library == 8)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'T-words'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 2: TACHEOMETER", moduleId);
            question1.text = "Which of these";
            question2.text = "is not an existing";
            question3.text = "word in the";
            question4.text = "T-words module?";
            ButtonAns = 2;
        }
        //Snooker
        else if (correctIndex == 1 && Library == 8)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Snooker'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 1: 1 POINT", moduleId);
            question1.text = "What is the value";
            question2.text = "of the red ball";
            question3.text = "in Snooker?";
            ButtonAns = 1;
        }
        //Benedict Cumberbatch
        else if (correctIndex == 2 && Library == 8)
        {
            Debug.LogFormat("[Module Homework #{0}] The question of this module is 'Benedict Cumberbatch'", moduleId);
            Debug.LogFormat("[Module Homework #{0}] Its answer would be Answer 3: BUTT", moduleId);
            question1.text = "Which of these";
            question2.text = "Forenames is";
            question3.text = "also a surname";
            question4.text = "in Benedict?";
            ButtonAns = 1;
        }
        Calculation();
    }

    void Calculation()
    {
        //Answer Calculation...
        int Homework = 0;
        Homework = BombInfo.GetSerialNumberNumbers().First();
        string Indic = string.Join("", BombInfo.GetIndicators().ToArray());
        if (BombInfo.GetSerialNumberLetters().Any("SCHOOL".Contains))
        {
            Debug.LogFormat("[Module Homework #{0}] Since there is a letter in the Serial that is also in school, +3 to the base nr.", moduleId);
            Homework = Homework + 3;
        }
        if (Indic.Any("STUDENT".Contains))
        {
            Debug.LogFormat("[Module Homework #{0}] Since any of the indicators contain a letter in 'Student', +2 to the base nr.", moduleId);
            Homework = Homework + 2;
        }
        if (BombInfo.IsPortPresent(Port.Parallel))
        {
            Debug.LogFormat("[Module Homework #{0}] Since a Parallel port is present, +2 to the base number", moduleId);
            Homework = Homework + 2;
        }
        if (BombInfo.IsIndicatorPresent(Indicator.NSA) || BombInfo.IsIndicatorPresent(Indicator.FRK))
        {
            Debug.LogFormat("[Module Homework #{0}] Since the Indicator 'FRK' or 'NSA' is present, +2 to the base nr.", moduleId);
            Homework = Homework + 2;
        }
        if (BombInfo.GetSerialNumberLetters().Any("AEIOU".Contains))
        {
            Debug.LogFormat("[Module Homework #{0}] Since the Serial contains a vowel, +5 to the base nr.", moduleId);
            Homework = Homework + 5;
        }
        if (BombInfo.GetBatteryCount(Battery.D) > 1)
        {
            Debug.LogFormat("[Module Homework #{0}] Since there is 2 or more D batteries, +2 to the base nr.", moduleId);
            Homework = Homework + 2;
        }
        if (BombInfo.IsIndicatorOn(Indicator.BOB))
        {
            Debug.LogFormat("[Module Homework #{0}] Attention! Indicator 'BOB' is present and lit! The base number will be reset.", moduleId);
            Homework = 1;
        }
        Debug.LogFormat("[Module Homework #{0}] The Base Number is {1}.", moduleId, Homework);

        //And now, the answer.
        if (Homework <= 6)
        {
            Debug.LogFormat("[Module Homework #{0}] The homework is from Elementary School", moduleId);
            LogAnswer();
            return;
        }
        else if (Homework >= 7 && Homework <= 12)
        {
            Debug.LogFormat("[Module Homework #{0}] The homework is from High School", moduleId);
            ButtonAns = ButtonAns + 1;
        }
        else if (Homework >= 13 && Homework <= 18)
        {
            Debug.LogFormat("[Module Homework #{0}] The homework is from University", moduleId);
            ButtonAns = ButtonAns + 2;
        }
        else if (Homework >= 19)
        {
            Debug.LogFormat("[Module Homework #{0}] The homework is from the Keep Learning And Nobody Explodes school", moduleId);
            ButtonAns = ButtonAns + 3;
        }
        AnswerCheck();
    }

    //if the answer is greater than 4
    void AnswerCheck()
    {
        if (ButtonAns > 4)
        {
            ButtonAns = ButtonAns - 4;
            AnswerCheck();
        }
        else
        {
            LogAnswer();
        }
    }

    void LogAnswer()
    {
        Debug.LogFormat("[Module Homework #{0}] The button that must be pressed is {1}", moduleId, ButtonAns);
        Debug.LogFormat("[Module Homework #{0}] -----------------------------------------------------------------------------", moduleId);
    }

    void Solve()
    {
        Intro.text = "Grade:";
        question1.text = "";
        question2.text = "";
        question3.text = "";
        question4.text = "";
        GetComponent<KMBombModule>().HandlePass();
        button1Obj.SetActive(false);
        button2Obj.SetActive(false);
        button3Obj.SetActive(false);
        button4Obj.SetActive(false);
        AnswerText.SetActive(false);
        Grade.SetActive(true);
    }

    //The actual time limit. (1 minutes)
    IEnumerator Countdown()
    {
        for (int i = 0; i < 61; i++)
        {
            if (Active == true)
            {
                int TimeLeft = i;
                Hands.gameObject.transform.Rotate(new Vector3(-6f, 0, 0));
                Clock.material.color = Color.Lerp(Color.green, Color.red, i / 60f);
                if (TimeLeft == 60)
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    StopCoroutine("Countdown");
                    StartCoroutine("Countdown");
                }
            }
            yield return new WaitForSecondsRealtime(1);
        }
    }

    protected bool StartLesson()
    {
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (lessonStart == 0)
        {
            StartCoroutine("Countdown");
            Pencil.OnInteract = Empty;
            Active = true;
            Debug.LogFormat("[Module Homework #{0}] -----------------------------------------------------------------------------", moduleId);
            Debug.LogFormat("[Module Homework #{0}] The lesson has started! Good luck.", moduleId);
            Init();
        }
        else
        {
            return false;
        }
        return false;
    }
    

    protected bool Button1()
    {
        StopCoroutine("Countdown");
        GetComponent<KMSelectable>().AddInteractionPunch();
        Debug.LogFormat("[Module Homework #{0}] Button pressed: Button 1", moduleId, ButtonAns);
        if (ButtonAns == 1 && lessonStart == 1)
        {
            Solve1.material.color = new Color32(124, 252, 0, 1);
            LED1.material.color = new Color32(0, 255, 0, 1);
            Solve();
        }
        else if (lessonStart == 0)
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Module Homework #{0}] Class hasn't started yet! Strike handed.", moduleId);
        }
        else
        {
            Debug.LogFormat("[Module Homework #{0}] Incorrect button! Strike handed.", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            Hands.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Init();
            StartCoroutine("Countdown");
            Solve1.material.color = new Color32(255, 0, 0, 1);
            LED1.material.color = new Color32(255, 0, 0, 1);
        }
        Audio.PlaySoundAtTransform("PencilDrawing", transform);
        return false;
    }

    protected bool Button2()
    {
        StopCoroutine("Countdown");
        Debug.LogFormat("[Module Homework #{0}] Button pressed: Button 2", moduleId, ButtonAns);
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (ButtonAns == 2 && lessonStart == 1)
        {
            Solve1.material.color = new Color32(124, 252, 0, 1);
            LED2.material.color = new Color32(0, 255, 0, 1);
            Solve();
        }
        else if (lessonStart == 0)
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Module Homework #{0}] Class hasn't started yet! Strike handed.", moduleId);
        }
        else
        {
            Debug.LogFormat("[Module Homework #{0}] Incorrect button! Strike handed.", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            Init();
            StartCoroutine("Countdown");
            Solve1.material.color = new Color32(255, 0, 0, 1);
            LED2.material.color = new Color32(255, 0, 0, 1);
            Hands.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        Audio.PlaySoundAtTransform("PencilDrawing", transform);
        return false;
    }

    protected bool Button3()
    {
        StopCoroutine("Countdown");
        Debug.LogFormat("[Module Homework #{0}] Button pressed: Button 3", moduleId, ButtonAns);
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (ButtonAns == 3 && lessonStart == 1)
        {
            Solve1.material.color = new Color32(124, 252, 0, 1);
            LED3.material.color = new Color32(0, 255, 0, 1);
            Solve();
        }
        else if (lessonStart == 0)
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Module Homework #{0}] Class hasn't started yet! Strike handed.", moduleId);
        }
        else
        {
            Debug.LogFormat("[Module Homework #{0}] Incorrect button! Strike handed.", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            Hands.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Init();
            StartCoroutine("Countdown");
            Solve1.material.color = new Color32(255, 0, 0, 1);
            LED3.material.color = new Color32(255, 0, 0, 1);
        }
        Audio.PlaySoundAtTransform("PencilDrawing", transform);
        return false;
    }

    protected bool Button4()
    {
        StopCoroutine("Countdown");
        Debug.LogFormat("[Module Homework #{0}] Button pressed: Button 4", moduleId, ButtonAns);
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (ButtonAns == 4 && lessonStart == 1)
        {
            Solve1.material.color = new Color32(124, 252, 0, 1);
            LED4.material.color = new Color32(0, 255, 0, 1);
            Solve();
        }
        else if (lessonStart == 0)
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Module Homework #{0}] Class hasn't started yet! Strike handed.", moduleId);
        }
        else
        {
            Debug.LogFormat("[Module Homework #{0}] Incorrect button! Strike handed.", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            Hands.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Init();
            StartCoroutine("Countdown");
            Solve1.material.color = new Color32(255, 0, 0, 1);
            LED4.material.color = new Color32(255, 0, 0, 1);
        }
        Audio.PlaySoundAtTransform("PencilDrawing", transform);
        return false;
    }

    protected bool Empty()
    {
        return false;
    }
}