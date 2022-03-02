// Murat Sancak

using UnityEngine;

namespace murasanca
{
    public class Close : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] gOs = new GameObject[3]; // gOs: Game Objects.

        private readonly Vector2 b = Siren.b; // b: Banner.

        private readonly Vector2[]
            v2s0 = new Vector2[8], // v2s0: Vector2's 0.
            v2s1 = new Vector2[8]; // v2s0: Vector2's 1.

        private readonly WaitForSeconds wFS = Siren.wFS; // wFS: Wait For Seconds.

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
            for (int i = 0; i < gOs.Length; i++)
            {
                v2s0[i] = b + gOs[i].GetComponent<RectTransform>().anchoredPosition;
                v2s1[i] = gOs[i].GetComponent<RectTransform>().anchoredPosition;
            }
        }

        private void Start() => StartCoroutine(Enumerator());

        // Murat Sancak

        private System.Collections.IEnumerator Enumerator()
        {
            while (true)
            {
                for (int i = 0; i < gOs.Length; i++)
                    gOs[i].GetComponent<RectTransform>().anchoredPosition = Vector2s[i];

                yield return wFS;
            }
        }

        // Murat Sancak

        public void Load(int s) => Scene.Load(s); // s: Scene.

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else // UNITY_ANDROID
            Application.Quit();
#endif
        }

        public void Reload() => Preferences.Reload();
    }
}

// Murat Sancak