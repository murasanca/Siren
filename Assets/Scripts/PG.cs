// Murat Sancak

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PG:MonoBehaviour // PG: Play Games.
{
    public static PG pG; // pG: Play Games.

    // Murat Sancak

    private void Awake()
    {
        if(pG is null)
            pG=this;
        else if(pG!=this)
            Destroy(gameObject);
        DontDestroyOnLoad(pG);
    }

    private void Start()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled=true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate
        (
            (bool success) =>
            {
                if(success)
                {
                    ((PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);

                    if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex is 0) // Siren.
                        Siren.g.interactable=Siren.s.interactable=true;
                }
            }
        );
    }

    // Murat Sancak

    public static void Achievement(int a) // a: Achievement.
    {
        if(Social.localUser.authenticated)
            switch(a)
            {
                case 1:
                    Social.ReportProgress(PGS.achievement_1,100,success => { });
                    break;
                case 2:
                    Social.ReportProgress(PGS.achievement_2,100,success => { });
                    break;
                case 3:
                    Social.ReportProgress(PGS.achievement_3,100,success => { });
                    break;
                case 4:
                    Social.ReportProgress(PGS.achievement_4,100,success => { });
                    break;
                case 8:
                    Social.ReportProgress(PGS.achievement_8_2,100,success => { });
                    break;
                case 9:
                    Social.ReportProgress(PGS.achievement_8,100,success => { });
                    break;
                default:
                    break;
            }
    }
    public static void Achievements() => Social.ShowAchievementsUI();

    public static void Leaderboard()
    {
        if(Social.localUser.authenticated)
            PlayGamesPlatform.Instance.LoadScores
            (
                PGS.leaderboard_siren,
                LeaderboardStart.PlayerCentered,
                1,
                LeaderboardCollection.Public,
                LeaderboardTimeSpan.AllTime,
                (lSD) => Social.ReportScore(++lSD.PlayerScore.value,PGS.leaderboard_siren,success => { }));  // lSD: Leaderboard Score Data.
    }
    public static void Leaderboards() => Social.ShowLeaderboardUI();
}

// Murat Sancak