// Murat Sancak

using UnityEngine;
using UnityEngine.Purchasing;

namespace murasanca
{
    public class IAP : MonoBehaviour, IStoreListener // IAP: In-App Purchase.
    {
        private ConfigurationBuilder cB; // cB: Configuration Builder.

        private const string a = "com.murasanca.siren.advertisement"; // a: Advertisement.

        private static IExtensionProvider eP; // eP: Extension Provider.

        private static IStoreController sC; // sC: Store Controller.

        public static IAP iap; // iap: In-App Purchase.

        // Murat Sancak

        public static bool II => eP is not null && sC is not null; // II: Is Initialized.

        private static Product Product
        {
            get
            {
                if (II)
                    return sC.products.WithStoreSpecificID(a);
                else
                    return null;
            }
        }

        // Murat Sancak

        private void Awake()
        {
            if (iap is null)
                iap = this;
            else if (iap != this)
                Destroy(gameObject);
            DontDestroyOnLoad(iap);
        }

        private void Start()
        {
            (cB = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance())).AddProduct(a, ProductType.NonConsumable);
            UnityPurchasing.Initialize(iap, cB);
        }

        // Murat Sancak

        public static void Checkmark()
        {
            if (II)
            {
                if (Product is not null && Product.availableToPurchase)
                    sC.InitiatePurchase(Product);
                else
                    Handheld.Vibrate();
            }
            else
                Handheld.Vibrate();
        }

        public static bool HR() // HR: Has Receipt, p: Product.
        {
            if (II)
                return Product.hasReceipt;
            else
                return false;
        }

        // Murat Sancak

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs pEA) // pEA: Purchase Event Args.
        {
            Monetization.Hide();
            Settings.Close();

            return PurchaseProcessingResult.Complete;
        }

        public void OnInitialized(IStoreController sC, IExtensionProvider eP) // sC: Store Controller, eP: Extension Provider.
        {
            IAP.eP = eP;
            IAP.sC = sC;
        }

        public void OnInitializeFailed(InitializationFailureReason iFR) // iFR: Purchase Failure Reason.
        {
            (cB = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance())).AddProduct(a, ProductType.NonConsumable);
            UnityPurchasing.Initialize(iap, cB);
        }

        public void OnPurchaseFailed(Product p, PurchaseFailureReason pFR) // p: Product, pFR: Purchase Failure Reason.
        {
            Handheld.Vibrate();
            Settings.Close();
        }
    }
}

// Murat Sancak