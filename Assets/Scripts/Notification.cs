// Murat Sancak

using System;
using Unity.Notifications.Android;
using UnityEngine;

namespace murasanca
{
    public class Notification : MonoBehaviour
    {
        public static Notification n; // n: Notification.

        // Murat Sancak

        private void Awake()
        {
            if (n is null)
                n = this;
            else if (n != this)
                Destroy(gameObject);
            DontDestroyOnLoad(n);
        }

        private void Start()
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.RegisterNotificationChannel
            (
                new("S", "Siren", "It's not road rage if you have Siren.", Importance.High)
                {
                    CanBypassDnd = true,
                    CanShowBadge = true,
                    // Description = "It's not road rage if you have Siren.",
                    EnableLights = true,
                    EnableVibration = true,
                    // Id = "S",
                    // Importance = Importance.High,
                    LockScreenVisibility = LockScreenVisibility.Public,
                    // Name = "Siren",
                    VibrationPattern = new long[8] { 0, 1, 2, 4, 8, 16, 32, 64 }
                }
            );
            AndroidNotificationCenter.SendNotification
            (
                new("Siren", "It's not road rage if you have Siren.", DateTime.Now.AddDays(1), new TimeSpan(864000000000), "small") // 864.000.000.000
                {
                    Color = Color.cyan,
                    CustomTimestamp = DateTime.Now.AddDays(1),
                    // FireTime = DateTime.Now.AddDays(1),
                    Group = "Murat Sancak",
                    GroupAlertBehaviour = GroupAlertBehaviours.GroupAlertAll,
                    GroupSummary = true,
                    IntentData = "Siren",
                    LargeIcon = "large",
                    Number = 1,
                    // RepeatInterval = new TimeSpan(864000000000), // 864.000.000.000
                    ShouldAutoCancel = false,
                    ShowTimestamp = true,
                    // SmallIcon = "small",
                    SortKey = "Siren",
                    Style = NotificationStyle.BigTextStyle,
                    // Text = "It's not road rage if you have Siren.",
                    // Title = "Siren",
                    UsesStopwatch = false
                },
                "S"
            );
        }
    }
}

// Murat Sancak