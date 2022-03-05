// Murat Sancak

using UnityEngine;

namespace murasanca
{
    public class Sound : MonoBehaviour
    {
        public static AudioSource
            bAS, // bAS: Blue Audio Source.
            gAS, // gAS: Green Audio Source.
            oAS, // oAS: Orange Audio Source.
            rAS; // rAS: Red Audio Source.

        public static int p = 0; // p: Playing.

        public static Sound s; // s: Sound.

        // Murat Sancak

        public static bool IBP => bAS.isPlaying; // IBP: Is Blue Playing.
        public static bool IGP => gAS.isPlaying; // IGP: Is Green Playing.
        public static bool IOP => oAS.isPlaying; // IOP: Is Orange Playing.
        public static bool IRP => rAS.isPlaying; // IRP: Is Red Playing.

        public static float BP // BP: Blue Pitch.
        {
            get => bAS.pitch;
            set => bAS.pitch = value;
        }
        public static float GP // GP: Green Pitch.
        {
            get => gAS.pitch;
            set => gAS.pitch = value;
        }
        public static float OP // OP: Orange Pitch.
        {
            get => oAS.pitch;
            set => oAS.pitch = value;
        }
        public static float RP // RP: Red Pitch.
        {
            get => rAS.pitch;
            set => rAS.pitch = value;
        }

        public static float BV // BV: Blue Volume.
        {
            get => bAS.volume;
            set => bAS.volume = value;
        }
        public static float GV // GV: Green Volume.
        {
            get => gAS.volume;
            set => gAS.volume = value;
        }
        public static float OV // OV: Orange Volume.
        {
            get => oAS.volume;
            set => oAS.volume = value;
        }
        public static float RV // RV: Red Volume.
        {
            get => rAS.volume;
            set => rAS.volume = value;
        }

        // Murat Sancak

        private void Awake()
        {
            if (s is null)
                s = this;
            else if (s != this)
                Destroy(gameObject);
            DontDestroyOnLoad(s);

            bAS = GameObject.Find("Blue Audio Source").GetComponent<AudioSource>();
            gAS = GameObject.Find("Green Audio Source").GetComponent<AudioSource>();
            oAS = GameObject.Find("Orange Audio Source").GetComponent<AudioSource>();
            rAS = GameObject.Find("Red Audio Source").GetComponent<AudioSource>();
        }

        private void Start()
        {
            bAS.pitch = gAS.pitch = oAS.pitch = rAS.pitch = Preferences.P;
            bAS.volume = gAS.volume = oAS.volume = rAS.volume = Preferences.V;
        }

        // Murat Sancak

        public static void Blue(bool p) // p: Play.
        {
            if (p)
            {
                ++Sound.p;
                bAS.Play();
            }
            else
            {
                --Sound.p;
                bAS.Pause();
            }
        }

        public static void Green(bool p) // p: Play.
        {
            if (p)
            {
                ++Sound.p;
                gAS.Play();
            }
            else
            {
                --Sound.p;
                gAS.Pause();
            }
        }

        public static void Orange(bool p) // p: Play.
        {
            if (p)
            {
                ++Sound.p;
                oAS.Play();
            }
            else
            {
                --Sound.p;
                oAS.Pause();
            }
        }

        public static void Red(bool p) // p: Play.
        {
            if (p)
            {
                ++Sound.p;
                rAS.Play();
            }
            else
            {
                --Sound.p;
                rAS.Pause();
            }
        }
    }
}

// Murat Sancak