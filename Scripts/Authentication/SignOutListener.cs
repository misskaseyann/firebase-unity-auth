using UnityEngine;
using UnityEngine.UI;

public class SignOutListener : MonoBehaviour
{
  public Button button;
  protected Firebase.Auth.FirebaseAuth auth;

  // Start is called before the first frame update
  void Start()
  {
    auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

    button.onClick.AddListener(() => auth.SignOut());
  }

}
