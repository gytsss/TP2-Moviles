using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System;
using TMPro;

public class PlayGamesAchievements : MonoBehaviour
{
    public static PlayGamesAchievements instance;

    public TextMeshProUGUI detailsText;

    public static bool active = false;

    private void Awake()
    {
        instance = this;
    }

    public int score;

    private void Start()
    {
        if (!active)
        {
            DontDestroyOnLoad(this);
            active = true;
        }
        else
        {
            Destroy(this);
        }

        try
        {
#if UNITY_ANDROID

            SignIn();

            // PlayGamesPlatform.DebugLogEnabled = true;
            // PlayGamesPlatform.Activate();
            // Social.localUser.Authenticate((bool success) => { });
#endif
        }
        catch (Exception exception)
        {
            Debug.Log("Exception: " + exception);
        }
    }

    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            string id = PlayGamesPlatform.Instance.GetUserId();
            string imgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();

            detailsText.text = "Success \n " + name;
        }
        else
        {
            detailsText.text = "Sign in failed!!";
        }
    }

    public void SendScore()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard_leaderboard, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
            //Social.ShowAchievementsUI();
        }
    }

    public void EnterLevel1()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_level_1, 100f, success => { });
            PlayGamesPlatform.Instance.UnlockAchievement(GPGSIds.achievement_enter_level_2, success => { });
        }
    }
    public void EnterLevel2()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_enter_level_2, 100f, success => { });
        }
    }
    public void WinLevel3()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_all_net, 100f, success => { });
        }
    }
    public void PurchaseFootball()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_football_player, 100f, success => { });
        }
    }
}