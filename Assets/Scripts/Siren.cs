// Murat Sancak

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace murasanca
{
    public class Siren : MonoBehaviour
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
        private GameObject[] gOs = new GameObject[8]; // gOs: Game Objects.

        private readonly Vector2[]
            v2s0 = new Vector2[8], // v2s0: Vector2's 0.
            v2s1 = new Vector2[8]; // v2s0: Vector2's 1.

        private static Button
            bB, // bB: Blue Button.
            gB, // gB: Green Button.
            oB, // oB: Orange Button.
            rB; // rB: Red Button.

        private static GameObject cT; // cT: Coin Text (TMP).

        public static Button
            g, // g: Goblet.
            s; // s: Scroll.

        public readonly static Vector2 b = 90 * Vector2.up; // b: Banner.

        public readonly static WaitForSeconds wFS = new(1); // wFS: Wait For Seconds.

        // Murat Sancak

        private Vector2[] Vector2s
        {
            get
            {
                if (!Monetization.IBL || IAP.HR())
                    return v2s0;
                else
                    return v2s1;
            }
        }

        // Murat Sancak

        private void Awake()
        {
            (cT = GameObject.Find("Coin Text (TMP)")).GetComponent<TextMeshProUGUI>().text = Preferences.String();

            bB = GameObject.Find("Blue Button").GetComponent<Button>();
            gB = GameObject.Find("Green Button").GetComponent<Button>();
            oB = GameObject.Find("Orange Button").GetComponent<Button>();
            rB = GameObject.Find("Red Button").GetComponent<Button>();

            g = GameObject.Find("Goblet Button").GetComponent<Button>();
            s = GameObject.Find("Scroll Button").GetComponent<Button>();

            for (int i = 0; i < gOs.Length; i++)
            {
                v2s0[i] = b + gOs[i].GetComponent<RectTransform>().anchoredPosition;
                v2s1[i] = gOs[i].GetComponent<RectTransform>().anchoredPosition;
            }
        }

        private void Start()
        {
            Interactable();

            StartCoroutine(Enumerator());
        }

        // Murat Sancak

        private System.Collections.IEnumerator Enumerator()
        {
            while (true)
            {
                for (int i = 0; i < gOs.Length; i++)
                    gOs[i].GetComponent<RectTransform>().anchoredPosition = Vector2s[i];

                if (!IAP.HR() && !Monetization.iRL)
                    pB.interactable = false;
                else
                    pB.interactable = true;

                yield return wFS;
            }
        }

        // Murat Sancak

        public void Blue()
        {
            if (Sound.IBP)
            {
                Sound.Blue(false);
                bB.interactable = Preferences.C is not 0;
                bRI.SetActive(true);
            }
            else if (0 < Preferences.C)
            {
                Sound.Blue(true);
                bRI.SetActive(false);

                Coin(-1);
            }
        }

        public void Goblet() => PG.Leaderboards();

        public void Green()
        {
            if (Sound.IGP)
            {
                Sound.Green(false);
                gB.interactable = Preferences.C is not 0;
                gRI.SetActive(true);
            }
            else if (0 < Preferences.C)
            {
                Sound.Green(true);
                gRI.SetActive(false);

                Coin(-1);
            }
        }

        public void Load(int s) => Scene.Load(s); // s: Scene.

        public void Orange()
        {
            if (Sound.IOP)
            {
                Sound.Orange(false);
                oB.interactable = Preferences.C is not 0;
                oRI.SetActive(true);
            }
            else if (0 < Preferences.C)
            {
                Sound.Orange(true);
                oRI.SetActive(false);

                Coin(-1);
            }
        }

        public void Play() => Monetization.Rewarded();

        public void Red()
        {
            if (Sound.IRP)
            {
                Sound.Red(false);
                rB.interactable = Preferences.C is not 0;
                rRI.SetActive(true);
            }
            else if (0 < Preferences.C)
            {
                Sound.Red(true);
                rRI.SetActive(false);

                Coin(-1);
            }
        }

        public void Scroll() => PG.Achievements();

        public void Star() => Application.OpenURL("market://details?id=com.murasanca.Siren");

        public static void Coin(int coin)
        {
            Preferences.C += coin;
            cT.GetComponent<TextMeshProUGUI>().text = Preferences.String();

            if (Mathf.Sign(coin) is -1)
            {
                PG.Achievement(Sound.p);
                PG.Leaderboard();
            }
            else
            {
                if (Preferences.C is 8)
                    PG.Achievement(8);
                else if (Preferences.C is 9)
                    PG.Achievement(9);
            }

            Interactable();
        }

        public static void Interactable()
        {
            if (Preferences.C is not 0)
                bB.interactable = gB.interactable = oB.interactable = rB.interactable = true;
            else
            {
                bB.interactable = Sound.IBP;
                gB.interactable = Sound.IGP;
                oB.interactable = Sound.IOP;
                rB.interactable = Sound.IRP;
            }
        }
    }
}

// Murat Sancak