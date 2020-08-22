using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using System;
using Firebase;
using Firebase.Unity.Editor;

public class FirebaseExample : MonoBehaviour
{
    private DatabaseReference reference;

    public string test_key;
    [TextArea(3, 10)]
    public string test_json;

    private void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://temperature-3bda1.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestPush()
    {
        reference.Child(test_key).Push().SetRawJsonValueAsync(test_json);
    }

    public void JoinRoom()
    {
        // 방에 참가하면 ChildAdded 콜백 걸어두세여
        reference.ChildAdded += OnCommandRecieved;
        reference.Push().SetValueAsync(new Dictionary<string, object>()
        {
            { "command", "join" },
            { "name", "이름" }
        });
    }

    public void JoinRoom(string key)
    {
        reference.Child(key).ChildAdded += OnCommandRecieved;
        reference.Child(key).Push().SetValueAsync(new Dictionary<string, object>()
        {
            { "command", "join" },
            { "name", "이름" }
        });
    }

    private void OnCommandRecieved(object sender, ChildChangedEventArgs e)
    {
        var command = e.Snapshot.Value as Dictionary<string, object>;
        // 방법이 여러가지가 있는데 value 를 직접 뽑아오면 Dictionary<string, object> 형태로 불러와지고
        string command_name = e.Snapshot.Child("command").Value as string;
        // DataSnapshot 에서 뽑아오는 방법도 있음
        Vector2 position = new Vector2(Convert.ToInt32(e.Snapshot.Child("X").Value), Convert.ToInt32(e.Snapshot.Child("y").Value));
    }

    public void SendCommand(Dictionary<string, object> dic)
    {
        reference.Push().SetValueAsync(dic);
    }

    public void SendCommand(string json)
    {
        reference.Push().SetRawJsonValueAsync(json);
    }
}
public class User
{
    public string username;
    public string email;

    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
    }
}