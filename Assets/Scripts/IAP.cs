// Murat Sancak

using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class IAP:MonoBehaviour, IStoreListener // IAP: In-App Purchase.
{
    private ConfigurationBuilder cB; // cB: Configuration Builder.

    private const string a = "com.murasanca.siren.advertisement"; // a: Advertisement.

    private static IExtensionProvider eP; // eP: Extension Provider.

    private static IStoreController sC; // sC: Store Controller.

    public static IAP iap; // iap: In-App Purchase.

    // Murat Sancak

    public static bool II => eP is not null&&sC is not null; // II: Is Initialized.

    private static Product Product => II ? sC.products.WithStoreSpecificID(a) : null;

    // Murat Sancak

    private void Awake()
    {
        if(iap is null)
            iap=this;
        else if(iap!=this)
            Destroy(gameObject);
        DontDestroyOnLoad(iap);
    }

    private void Start() => Initialize();

    // Murat Sancak

    private void Initialize()
    {
        (cB=ConfigurationBuilder.Instance(StandardPurchasingModule.Instance())).AddProduct(a,ProductType.NonConsumable);
        UnityPurchasing.Initialize(iap,cB);
    }

    public static bool HR() => II&&Product.hasReceipt; // HR: Has Receipt.

    public static void Checkmark()
    {
        if(II)
        {
            if(Product is not null&&Product.availableToPurchase)
                sC.InitiatePurchase(Product);
            else
                Handheld.Vibrate();
        }
        else
            Handheld.Vibrate();
    }

    // Murat Sancak

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs pEA) // pEA: Purchase Event Args.
    {
        if(SceneManager.GetActiveScene().buildIndex is 2) // Settings.
            Settings.Close();

        Monetization.Hide();

        return PurchaseProcessingResult.Complete;
    }

    public void OnInitialized(IStoreController sC,IExtensionProvider eP) // sC: Store Controller, eP: Extension Provider.
    {
        IAP.eP=eP;
        IAP.sC=sC;
    }

    public void OnInitializeFailed(InitializationFailureReason iFR) => Initialize(); // iFR: Purchase Failure Reason.

    public void OnPurchaseFailed(Product p,PurchaseFailureReason pFR) // p: Product, pFR: Purchase Failure Reason.
    {
        Handheld.Vibrate();

        if(SceneManager.GetActiveScene().buildIndex is 2) // Settings.
            Settings.Close();
    }
}

// Murat Sancak