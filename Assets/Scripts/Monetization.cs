// Murat Sancak

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace murasanca
{
    public class Monetization : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
#if UNITY_IOS
        private string const
            b = "banner", // b: Banner.
            g = "3767230", // g: Game.
            i = "video", // i: Interstitial.
            r = "rewardedVideo"; // r: Rewarded.
            
#else // UNITY_ANDROID
        private const string
            b = "banner", // b: Banner.
            g = "3767231", // g: Game.
            i = "video", // i: Interstitial.
            r = "rewardedVideo"; // r: Rewarded.
#endif

        private const bool t = true; // t: Test.

        private readonly System.NotImplementedException NIE = new(); // NIE: Not Implemented Exception.

        private readonly WaitForSeconds wFS = Siren.wFS; // wFS: Wait For Seconds.

        private static int s = -1; // s: Scene.

        public static bool
            iIL = false, // iIL: is Interstitial Loaded.
            iRL = false, // iRL: is Rewarded Loaded.

            // iBS = false, // iBS: Is Banner Showing.
            // iIS = false, // iIS: Is Interstitial Showing.
            iRS = false; // iRS: Is Rewarded Showing.

        public static Monetization m; // m: Monetization.

        // Murat Sancak

        public static bool IBL => Advertisement.Banner.isLoaded; // IBR: Is Banner Loaded.
        public static bool II => Advertisement.isInitialized; // II: Is Initialized.

        // Murat Sancak

        private void Awake()
        {
            if (m is null)
                m = this;
            else if (m != this)
                Destroy(gameObject);
            DontDestroyOnLoad(m);
        }

        private void Start() => StartCoroutine(Initialize());

        // Murat Sancak

        private IEnumerator Initialize()
        {
            while (true)
            {
                if (!IAP.HR())
                    if (!II)
                        Advertisement.Initialize(g, t, m);
                    else
                    {
                        if (!IBL)
                            Advertisement.Banner.Load(b);
                        else
                        {
                            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                            Advertisement.Banner.Show(b);
                        }

                        if (!iIL)
                            Advertisement.Load(i, m);

                        if (!iRL)
                            Advertisement.Load(r, m);
                    }

                yield return wFS;
            }
        }

        // Murat Sancak

        public static void Hide() => Advertisement.Banner.Hide();

        public static void Interstitial(int s)
        {
            if (!iIL || IAP.HR())
                Scene.Reward(Monetization.s = s);
            else
            {
                Monetization.s = s;

                Advertisement.Show(i, m);
            }
        }

        public static void Rewarded()
        {
            if (IAP.HR())
                Siren.Coin(1);
            else if (iRL)
                Advertisement.Show(r, m);
        }

        // Murat Sancak

        public void OnInitializationComplete()
        {
            if (!IBL)
                Advertisement.Banner.Load(b);
            else
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show(b);
            }
        }

        public void OnInitializationFailed(UnityAdsInitializationError uAIE, string f) => Advertisement.Initialize(g, t, m); // uAIE: Unity Ads Initialization Error, f: Failure.

        public void OnUnityAdsAdLoaded(string a) // a: Advertisement.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    iIL = true;
                    break;
                case r:
                    iRL = true;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsFailedToLoad(string a, UnityAdsLoadError uALE, string f) // a: Advertisement, uALE: Unity Ads Load Error, f: Failure.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.Load();
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    iIL = false;

                    Advertisement.Load(i, m);
                    break;
                case r:
                    iRL = false;

                    Advertisement.Load(r, m);
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowClick(string a) => throw NIE; // a: Advertisement.

        public void OnUnityAdsShowComplete(string a, UnityAdsShowCompletionState uASCS) // a: Advertisement, uASCS: Unity Ads Show Completion State.
        {
            switch (a)
            {
                case b:
                    // iBS = false;

                    if (!IBL)
                        Advertisement.Banner.Load(b);
                    else
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    break;
                case i:
                    if (!iIL)
                        Advertisement.Load(i, m);

                    // iIS = false;

                    Scene.Reward(s);
                    break;
                case r:
                    if (!iRL)
                        Advertisement.Load(r, m);

                    if (iRS && uASCS is UnityAdsShowCompletionState.COMPLETED)
                        Siren.Coin(1);
                    else // showCompletionState is UnityAdsShowCompletionState.SKIPPED || showCompletionState is UnityAdsShowCompletionState.UNKNOWN
                        Handheld.Vibrate();

                    iRS = false;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowFailure(string a, UnityAdsShowError uASE, string f) // a: Advertisement, uASE: Unity Ads Show Error, f: Failure.
        {
            switch (a)
            {
                case b:
                    // iBS = false;

                    if (!IBL)
                        Advertisement.Banner.Load(b);
                    else
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    break;
                case i:
                    Handheld.Vibrate();

                    if (!iIL)
                        Advertisement.Load(i, m);

                    // iIS = false;
                    break;
                case r:
                    Handheld.Vibrate();

                    if (!iRL)
                        Advertisement.Load(r, m);

                    iRS = false;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowStart(string a) // a: Advertisement.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

                    // iBS = true;
                    break;
                case i:
                    // iIS = true;
                    break;
                case r:
                    iRS = true;
                    break;
                default:
                    break;
            }
        }
    }
}

// Murat Sancak