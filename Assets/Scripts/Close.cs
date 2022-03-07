// Murat Sancak

using UnityEngine;

public class Close:MonoBehaviour
{
    [SerializeField]
    private RectTransform uP; // uP: Upper Panel.

    private readonly WaitForSeconds wFS = Siren.wFS; // wFS: Wait For Seconds.

    // Murat Sancak

    private void Start() => StartCoroutine(Enumerator());

    // Murat Sancak

    private System.Collections.IEnumerator Enumerator()
    {
        while(true)
        {
            if(!Monetization.IBL||IAP.HR())
                uP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,256);
            else
                uP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,346);

            yield return wFS;
        }
    }

    // Murat Sancak

    public void Load(int s) => Scene.Load(s); // s: Scene.

    public void Quit() =>
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
#else
            Application.Quit();
#endif

    public void Reload() => Preferences.Delete();
}

// Murat Sancak