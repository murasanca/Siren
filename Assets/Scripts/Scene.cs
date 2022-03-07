// Murat Sancak

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene:MonoBehaviour
{
    private readonly static WaitForSeconds // wFS: Wait For Seconds.
        wFS64 = new(16/15), // wFS64 = new(64 / 60).
        wFS128 = new(32/15); // wFS128 = new(128 / 60).

    private static Animator a; // a: Animator.

    public static Scene s; // s: Scene.

    // Murat Sancak

    private void Awake()
    {
        if(s is null)
            s=this;
        else if(s!=this)
            Destroy(gameObject);
        DontDestroyOnLoad(s);

        a=s.gameObject.GetComponent<Animator>();
    }

    private void Start() => StartCoroutine(Single());

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            if(SceneManager.GetActiveScene().buildIndex is 0) // Siren.
                Load(1);
            else // Close || Settings.
                Load(0);
    }

    // Murat Sancak

    private static IEnumerator Double(int s) // s: Scene.
    {
        a.Play("Scene Canvas 0");
        a.SetTrigger("Scene Canvas 0");

        yield return wFS128;

        a.Play("Scene Canvas 1");
        a.ResetTrigger("Scene Canvas 0");

        SceneManager.LoadScene(s);
    }

    private static IEnumerator Single()
    {
        a.SetTrigger("Scene Canvas 1");
        a.Play("Scene Canvas 1");

        yield return wFS64;

        a.ResetTrigger("Scene Canvas 1");
    }

    // Murat Sancak

    public static void Load(int s) => Monetization.Interstitial(s); // s: Scene.

    public static void Reward(int s) => Scene.s.StartCoroutine(Double(s)); // s: Scene.
}

// Murat Sancak