using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Typing : Minigame
{
    [Header("Typing")]
    public TextMeshProUGUI wordLabel;
    public string goalWord;
    string[] possibleWords = new[]{"supercalifragilisticexpialidocious", "simsalida avenue", "apple", "labyrinth", "breeze", "chrysanthemum", "river", "kaleidoscope", "candle", "juxtaposition", "mountain", "ephemeral", "chair", "onomatopoeia", "blanket", "iridescent", "pencil", "quintessential", "window", "serendipity", "orange", "cacophony", "turtle", "incandescent", "flower", "inconspicuous", "notebook", "mischievous", "forest", "conscientious", "button", "translucent", "rainbow", "bewilderment", "sandwich", "idiosyncrasy", "bicycle", "harmonious", "pillow", "magnanimous", "cookie", "effervescent", "thunder", "camouflage", "pocket", "perseverance", "feather", "extraordinary", "candlelight", "renaissance", "banana", "metamorphosis", "dolphin", "exuberant", "suitcase", "quintessentially", "mirror", "phosphorescent", "sunflower", "exuberance", "backpack", "synchronization", "kitten", "bureaucracy", "umbrella", "cryptography", "lemonade", "circumstantial", "hammer", "equilibrium", "marshmallow", "vulnerability", "guitar", "inconceivable", "popcorn", "resilience", "dragonfly", "astrophysics", "mailbox", "paradigm", "shoelace", "hallucination", "snowflake", "benevolent", "cupcake", "miscellaneous", "waterfall", "hypothesis", "strawberry", "unequivocally", "lighthouse", "exhilaration", "teacup", "fluorescence", "sidewalk", "conscientiousness", "acorn", "interoperability", "butterfly", "pseudonym", "watermelon", "synchronization", "compass", "antidisestablishmentarianism"};
    public string currentTyping;

    bool keyboardActive;

    void Start()
    {
        SetNewWord();
    }
    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            
            if(Input.inputString.Length == 1)
            {
                if(!keyboardActive) return;
                TypeLetter(Input.inputString);
            }
        }
    }

    void TypeLetter(string letter)
    {
        letter = letter.ToLower();
        currentTyping = currentTyping + letter;

        if(currentTyping[currentTyping.Length-1] != goalWord[currentTyping.Length-1])
        {
            keyboardActive = false;
            Debug.Log("You Suck");
            Invoke("SetNewWord",1f);
            wordLabel.text = 
            "<color=green>" + currentTyping.Substring(0, currentTyping.Length-1) +
            "<color=red>" + letter + 
            "<color=grey>" + goalWord.Substring(currentTyping.Length-1);
            return;
        }
        else if(currentTyping == goalWord)
        {
            keyboardActive = false;
            Debug.Log("You Win!");
            Invoke("SetNewWord",1f);
        }
        ColorWord();


    }

    void ColorWord()
    {
        wordLabel.text = "<color=green>" + currentTyping.Substring(0,currentTyping.Length) + "</color>" + goalWord.Substring(currentTyping.Length);
    }

    void SetNewWord()
    {
        currentTyping = string.Empty;
        goalWord = possibleWords[Random.Range(0,possibleWords.Length)].ToLower();
        wordLabel.text = goalWord;
        keyboardActive = true;
    }
}
