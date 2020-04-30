using UnityEngine;
using Firebase.Extensions;

public class AuthSetup : MonoBehaviour
{
  public AuthManager authManager;
  private Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;

  // Start is called before the first frame update
  // When the app starts, check to make sure that we have
  // the required dependencies to use Firebase, and if not,
  // add them if possible.
  void Start()
  {
    Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
    {
      dependencyStatus = task.Result;
      if (dependencyStatus == Firebase.DependencyStatus.Available)
      {
        authManager.InitializeFirebase();
      }
      else
      {
        Debug.LogError(
          "Could not resolve all Firebase dependencies: " + dependencyStatus);
      }
    });
  }
}