using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class LeaderboardAndroid : MonoBehaviour
{

	public bool inGame;
	#region PUBLIC_VAR
	public string leaderboard;
	#endregion
	#region DEFAULT_UNITY_CALLBACKS
	void Start ()
	{
		#if UNITY_ANDROID
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		if (inGame == false) {
			LogIn ();
		}
		#endif

	}
	#endregion
	#region BUTTON_CALLBACKS
	/// <summary>
	/// Login In Into Your Google+ Account
	/// </summary>


	public void LogIn ()
	{
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					Debug.Log ("Login Sucess");
				} else {
					Debug.Log ("Login failed");
				}
			});
	}
	/// <summary>
	/// Shows All Available Leaderborad
	/// </summary>
	public void OnShowLeaderBoard ()
	{
		//#if UNITY_ANDROID
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI ("CgkItbTazPIBEAIQAQ"); // Show current (Active) leaderboard

		//#endif
	}
	/// <summary>
	/// Adds Score To leader board
	/// </summary>
	public void OnAddScoreToLeaderBorad (int x)
	{
		#if UNITY_ANDROID
		Social.ReportScore (x, "CgkItbTazPIBEAIQAQ", (bool success) =>
			{
				if (success) {
					Debug.Log ("Update Score Success");

				} else {
					Debug.Log ("Update Score Fail");
				}
			});
		#endif
	}
	/// <summary>
	/// On Logout of your Google+ Account
	/// </summary>

	#endregion
}