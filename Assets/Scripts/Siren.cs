// Murat Sancak

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Siren:MonoBehaviour
{
    [SerializeField]
    private Button pB; // pB: Play Button.

    [SerializeField]
    private GameObject
        bRI, // bRI: Blue Raw Image.
        gRI, // gRI: Green Raw Image.
        oRI, // oRI: Orange Raw Image.
        rRI; // rRI: Red Raw Image.

    [SerializeField]
    private RectTransform uP; // uP: Upper Panel.

    private static Button
        bB, // bB: Blue Button.
        gB, // gB: Green Button.
        oB, // oB: Orange Button.
        rB; // rB: Red Button.

    private static GameObject cT; // cT: Coin Text (TMP).

    public static Button
        g, // g: Goblet.
        s; // s: Scroll.

    public readonly static WaitForSeconds wFS = new(1); // wFS: Wait For Seconds.

    // Murat Sancak

    private void Awake()
    {
        (cT=GameObject.Find("Coin Text (TMP)")).GetComponent<TextMeshProUGUI>().text=Preferences.String();

        bB=GameObject.Find("Blue Button").GetComponent<Button>();
        gB=GameObject.Find("Green Button").GetComponent<Button>();
        oB=GameObject.Find("Orange Button").GetComponent<Button>();
        rB=GameObject.Find("Red Button").GetComponent<Button>();

        g=GameObject.Find("Goblet Button").GetComponent<Button>();
        s=GameObject.Find("Scroll Button").GetComponent<Button>();
    }

    private void Start()
    {
        Interactable();

        StartCoroutine(Enumerator());
    }

    // Murat Sancak

    private System.Collections.IEnumerator Enumerator()
    {
        while(true)
        {
            if(!Monetization.IBL||IAP.HR())
                uP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,256);
            else
                uP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,346);

            pB.interactable=IAP.HR()||Monetization.iRL;

            yield return wFS;
        }
    }

    // Murat Sancak

    public void Blue()
    {
        if(Sound.IBP)
        {
            Sound.Blue(false);
            bB.interactable=Preferences.C is not 0;
            bRI.SetActive(true);
        }
        else if(0<Preferences.C)
        {
            Sound.Blue(true);
            bRI.SetActive(false);

            Coin(-1);
        }
    }

    public void Goblet() => PG.Leaderboards();

    public void Green()
    {
        if(Sound.IGP)
        {
            Sound.Green(false);
            gB.interactable=Preferences.C is not 0;
            gRI.SetActive(true);
        }
        else if(0<Preferences.C)
        {
            Sound.Green(true);
            gRI.SetActive(false);

            Coin(-1);
        }
    }

    public void Load(int s) => Scene.Load(s); // s: Scene.

    public void Orange()
    {
        if(Sound.IOP)
        {
            Sound.Orange(false);
            oB.interactable=Preferences.C is not 0;
            oRI.SetActive(true);
        }
        else if(0<Preferences.C)
        {
            Sound.Orange(true);
            oRI.SetActive(false);

            Coin(-1);
        }
    }

    public void Play() => Monetization.Rewarded();

    public void Red()
    {
        if(Sound.IRP)
        {
            Sound.Red(false);
            rB.interactable=Preferences.C is not 0;
            rRI.SetActive(true);
        }
        else if(0<Preferences.C)
        {
            Sound.Red(true);
            rRI.SetActive(false);

            Coin(-1);
        }
    }

    public void Scroll() => PG.Achievements();

    public void Star() => Application.OpenURL("market://details?id=com.murasanca.Siren");

    public static void Coin(int c) // c: Coin.
    {
        Preferences.C+=c;
        cT.GetComponent<TextMeshProUGUI>().text=Preferences.String();

        if(Mathf.Sign(c) is -1)
        {
            PG.Achievement(Sound.p);
            PG.Leaderboard();
        }
        else
        {
            if(Preferences.C is 8)
                PG.Achievement(8);
            else if(Preferences.C is 9)
                PG.Achievement(9);
        }

        Interactable();
    }

    public static void Interactable()
    {
        if(Preferences.C is not 0)
            bB.interactable=gB.interactable=oB.interactable=rB.interactable=true;
        else
        {
            bB.interactable=Sound.IBP;
            gB.interactable=Sound.IGP;
            oB.interactable=Sound.IOP;
            rB.interactable=Sound.IRP;
        }
    }
}

// Murat Sancak