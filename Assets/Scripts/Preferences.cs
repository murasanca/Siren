// Murat Sancak

using UnityEngine;

namespace murasanca
{
    public class Preferences : PlayerPrefs
    {
        private readonly static float
            p, // p: Pitch.
            v; // v: Volume.

        private readonly static int c; // c: Coin.

        // Murat Sancak

        public static float P // P: Pitch.
        {
            get
            {
                if (!HasKey("p"))
                    P = 1;
                return GetFloat("p", p);
            }
            set
            {
                SetFloat("p", value);
                Save();
            }
        }

        public static float V // V: Volume.
        {
            get
            {
                if (!HasKey("v"))
                    V = .64f;
                return GetFloat("v", v);
            }
            set
            {
                SetFloat("v", value);
                Save();
            }
        }

        public static int C // C: Coin.
        {
            get
            {
                if (!HasKey("c"))
                    C = 2;
                return GetInt("c", c);
            }
            set
            {
                SetInt("c", value);
                Save();
            }
        }

        // Murat Sancak

        public static string String()
        {
            if (8 < C)
                return "8+";
            return C.ToString();
        }

        public static void Delete()
        {
            DeleteKey("p");
            DeleteKey("v");
        }
    }
}

// Murat Sancak