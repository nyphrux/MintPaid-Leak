using UnityEngine;
using Photon.Pun;
using KeyAuth;
using AetherTemp.Menu;
using GorillaNetworking;

public class RiftKeyAuthGUI : MonoBehaviour
{
    public static api KeyAuthApp = new api(
        name: "YourAppName",
        ownerid: "your_owner_id",
        secret: "your_secret",
        version: "1.0"
    );

    private bool isAuthenticated = false;
    private string licenseKey = "";
    private string code = "";
    private bool GUIEnabled = true;
    private bool act = false;
    private bool guibld = true;
    private bool arrayTrue = true;
    private float debo = 0;
    private Rect rect = new Rect(100, 100, 250, 150);

    void OnGUI()
    {
        if (!isAuthenticated)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 120), GUI.skin.box);
            GUILayout.Label("Enter License Key:");
            licenseKey = GUILayout.TextField(licenseKey);
            if (GUILayout.Button("Validate"))
            {
                KeyAuthApp.license(licenseKey);
                if (KeyAuthApp.response.success)
                {
                    isAuthenticated = true;
                    Debug.Log("[KeyAuth] License validated!");
                }
                else
                {
                    Debug.LogError("[KeyAuth] Invalid license!");
                }
            }
            GUILayout.EndArea();
            return;
        }

        if (GUIEnabled)
        {
            if (Input.GetKey(KeyCode.F3) && Time.time > debo + 0.5f)
            {
                debo = Time.time;
                act = !act;
            }

            if (PhotonNetwork.InRoom)
            {
                PhotonNetworkController.Instance.disableAFKKick = true;
            }

            if (guibld)
            {
                string room = PhotonNetwork.InRoom ? PhotonNetwork.CurrentRoom.Name : "No";
                GUIStyle gui = new GUIStyle { fontSize = 19, normal = { textColor = Color.Lerp(Color.grey, Color.white, Mathf.PingPong(Time.time, 1)) } };
                GUI.Label(new Rect(10, 10, 500, 60), $"In Room: <color=lime>{room}</color>\nUsername: <color=lime>{PhotonNetwork.LocalPlayer.NickName}</color>", gui);
            }

            if (arrayTrue)
            {
                GUIStyle legacyStyle = new GUIStyle
                {
                    fontSize = 15,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleRight,
                    normal = { textColor = Color.Lerp(Color.magenta, Color.green, Mathf.PingPong(Time.time, 1)) },
                    padding = new RectOffset(10, 10, 5, 5)
                };

                GUIStyle titleStyle = new GUIStyle
                {
                    fontSize = 20,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleRight,
                    normal = { textColor = Color.Lerp(Color.red, Color.grey, Mathf.PingPong(Time.time, 1)) }
                };

                GUIStyle lineStyle = new GUIStyle(GUI.skin.box)
                {
                    border = new RectOffset(1, 1, 1, 1),
                    fixedHeight = 2
                };

                GUILayout.BeginArea(new Rect(Screen.width - 205, 10, 210, Screen.height - 20));
                GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandHeight(true));
                GUILayout.Label("Nebula", titleStyle);
                GUILayout.Space(10);

                if (PhotonNetwork.InRoom)
                {
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        GUILayout.Label(player.NickName, legacyStyle);
                    }
                    GUILayout.Space(5);
                    GUILayout.Box("", lineStyle, GUILayout.ExpandWidth(true));
                    GUILayout.Space(5);
                }

                foreach (var buttons in Buttons.Players)
                {
                    foreach (var btn in buttons)
                    {
                        if (btn.enabled && GUILayout.Button(btn.buttonText, legacyStyle, GUILayout.Height(30)))
                        {
                            Toggle(btn.buttonText);
                        }
                    }
                }

                GUILayout.EndVertical();
                GUILayout.EndArea();
            }

            if (act)
            {
                rect = GUILayout.Window(0, rect, DrawWindow, PhotonNetwork.InRoom ? "<color=red>Room Manager</color>" : "<color=lime>Room Manager</color>");
            }
        }
    }

    private void DrawWindow(int id)
    {
        GUI.color = PhotonNetwork.InRoom ? Color.red : Color.green;
        GUI.contentColor = Color.white;
        GUI.backgroundColor = PhotonNetwork.InRoom ? Color.red : Color.green;

        GUILayout.BeginVertical();
        code = GUILayout.TextField(code.ToUpper());
        string text = PhotonNetwork.InRoom ? "Leave" : "Join";

        if (GUILayout.Button(text))
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.Disconnect();
            else
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(code.ToUpper(), JoinType.Solo);
        }

        GUILayout.EndVertical();
        GUI.DragWindow();
    }

    // Dummy method: replace with your real Toggle logic
    private void Toggle(string name)
    {
        Debug.Log($"Toggled: {name}");
    }
}
