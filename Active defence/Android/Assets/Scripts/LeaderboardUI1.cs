using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI1 : MonoBehaviour {

	#region PRIVATE_VARIABLES

	string leaderBoardID = "151228151";

	#endregion

	#region BUTTON_EVENT_HANDLER

	/// <summary>
	/// Raises the login event.
	/// </summary>
	/// <param name="id">Identifier.</param>

	public void Awake () {
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			LeaderboardManager.AuthenticateToGameCenter ();
		}
	}
	public void OnLogin(string id){
		LeaderboardManager.AuthenticateToGameCenter();
	}

	/// <summary>
	/// Raises the show leaderboard event.
	/// </summary>
	public void OnShowLeaderboard(){
		LeaderboardManager.ShowLeaderboard();
	}

	///<summary>
	/// Raises the post score event.
	/// </summary>
	public void OnPostScore(){
		//LeaderboardManager.ReportScore(GetComponent<Score>().MaxScore,leaderBoardID);
	}

	#endregion
}
