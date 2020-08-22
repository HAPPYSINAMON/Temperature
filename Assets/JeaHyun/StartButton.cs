using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private static StartButton instance = null;

    public static StartButton Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private DatabaseReference reference;
    private FirebaseAuth auth;
    public string user_id;

    public GameObject RoomUI;
    public GameObject GameStartUI;

    public GameObject RoomListbutton;
    public RectTransform veiwport;
    public RectTransform content;

    public FirebaseUser currentUser;
    User user;
    private string room_key;
    public string currentRoomName;
    public Dictionary<string, ParticipantInfo> CurrentParticipants;
    public Action OnRoomInfoChanged;

    public Text id;
    public Text name;
    public Text room;

    private FirebaseApp firebaseApp;

    public string UserId
    {
        get
        {
            return currentUser.UserId;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

#if UNITY_EDITOR
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://temperature-3bda1.firebaseio.com/");
#endif
        var options = new AppOptions() {
            ProjectId = "temperature-3bda1",
            DatabaseUrl = new Uri("https://temperature-3bda1.firebaseio.com"),
            ApiKey = "AIzaSyCzhbEw8KXQxleuwgqB2jLVgV7pkLDuWIw",
            AppId = "1:21158553730:android:143e5e6ffd54c40707ac9b",
            MessageSenderId = "21158553730",
            StorageBucket = "temperature-3bda1.appspot.com"
        };
        firebaseApp = FirebaseApp.Create(options, "com.Heaven.Temperature2");

        reference = FirebaseDatabase.GetInstance(firebaseApp).RootReference;
        auth = FirebaseAuth.GetAuth(firebaseApp);
    }

    private void Start()
    {
       
    }

    public void CreateAccount(string email, string password, Action<bool> OnCompleted)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                OnCompleted?.Invoke(true);
            }
            else
            {
                OnCompleted?.Invoke(false);
            }

        });
    }

    public async Task<bool> SignInWithEmail(string email, string password)
    {
        var user = await auth.SignInWithEmailAndPasswordAsync(email, password);
        if(user == null)
        {
            return false;
        }
        else
        {
            this.currentUser = user;
            return true;
        }
    }

    public async Task<bool> SignInAnonymously()
    {
        var user = await auth.SignInAnonymouslyAsync();
        if (user == null)
        {
            return false;
        }
        else
        {
            this.currentUser = user;
            return true;
        }
    }

    public async void ReadRoomList()
    {
        for(int i = 0; i<content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        var roomList = await GetRoomList();
        //var roomInfo = reference.Child("Room");

        foreach (var pair in roomList)
        {
            // DB 키
            Debug.Log(pair.Key);
            // 방 이름
            Debug.Log(pair.Value);
            //var sn = await roomInfo.Child(pair.Value).GetValueAsync();
            //Debug.Log(sn.ChildrenCount);

            int count = await GetUsersAsync(pair.Key);
            var index = Instantiate(RoomListbutton, new Vector3(0, 0, 0), Quaternion.identity);

            index.transform.parent = content.gameObject.transform;
            index.GetComponentInChildren<Text>().text = pair.Value + "("+count+"/6)";
            index.GetComponent<Button>().onClick.AddListener(()=>{ EnterRoom(pair.Key); });
        }
        content.sizeDelta = new Vector2(veiwport.sizeDelta.x, RoomListbutton.GetComponent<RectTransform>().sizeDelta.y * roomList.Count);
    }

    private async void Sample()
    {
        var roomList = await GetRoomList();
        foreach(var pair in roomList)
        {
            // DB 키
            Debug.Log(pair.Key);
            // 방 이름
            Debug.Log(pair.Value);
        }
        MakeRoom("새로운 방");
        // 방 씬으로 넘어가면 됨
        //씬으로 넘어간 다음에
        OnRoomInfoChanged = () =>
        {
            // UI 를 그리세요 여기서
        };
        var message = await ExitRoom();
        Debug.Log(message);
    }

    public async Task<Dictionary<string, string>> GetRoomList()
    {
        var snapshot = await reference.Child("Room").GetValueAsync();
        return (snapshot.Value as Dictionary<string, object>).ToDictionary(pair => pair.Key, pair => (pair.Value as Dictionary<string ,object>)["roomname"] as string);
    }

    public async void GetUserList(string d)
    {
        Debug.Log("유저 리스트");
        int count = 0;
        var room_ref = reference.Child("Room").Child(d);
        await room_ref.RunTransaction(mu =>
        {
            var roomInfo = mu.Value as Dictionary<string, object>;
            var users = roomInfo["users"] as Dictionary<string, object>;
            foreach (var pair in users)
            {
                var oo = users[pair.Key] as Dictionary<string, object>;
                var ii = oo["user"] as Dictionary<string, object>;
                Debug.Log(oo["team"]);
                Debug.LogError(oo["user"]);
                Debug.Log(ii["username"]);
            }
            //var userInfo = users["user"] as Dictionary<string, string>;

            return TransactionResult.Success(mu);
        });
    }

    public async void MakeRoom(string room_name)
    {
        var room_ref = reference.Child("Room").Push();
        var roomInfo = new Dictionary<string, object>();
        roomInfo["roomname"] = room_name;
        roomInfo["users"] = new Dictionary<string, object>()
        {
            { UserId,  new Dictionary<string, object>() {
                    { "user", this.user.ToDictionary() },
                    { "is_master", true },
                    { "team", "red" }
                }
            }
        };
        await room_ref.SetValueAsync(roomInfo);
        room_ref.ValueChanged += RoomInfoChanged;
    }

    private void RoomInfoChanged(object sender, ValueChangedEventArgs e)
    {
        this.currentRoomName = e.Snapshot.Child("roomname").Value as string;
        this.CurrentParticipants = (e.Snapshot.Child("users").Value as Dictionary<string, object>).ToDictionary(pair => pair.Key, pair => ParticipantInfo.FromDictionary(pair.Value as Dictionary<string, object>));
        OnRoomInfoChanged?.Invoke();
    }
    public async Task<int> GetUsersAsync(string key)
    {
        int count = 0;
        var room_ref = reference.Child("Room").Child(key);
        await room_ref.RunTransaction(mu =>
        {
            var roomInfo = mu.Value as Dictionary<string, object>;
            var users = roomInfo["users"] as Dictionary<string, object>;

            count = users.Count;

            return TransactionResult.Success(mu);
        });
        return count;
    }

    public async void EnterRoom(string key)
    {
        var message = await JoinRoom(key);
        GetUserList(key);
        if (message.Equals("성공"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public async void OutRoom()
    {
        var message = await ExitRoom();
        if (message.Equals("성공"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public async Task<string> JoinRoom(string room_key)
    {
        string message = "성공";
        await reference.Child("Room").Child(room_key).RunTransaction(mutableData =>
        {
            var roomInfo = mutableData.Value as Dictionary<string, object>;
            var participants = roomInfo["users"] as Dictionary<string, object>;
            int redCount = 0;
            int blueCount = 0;
            bool is_master = true;
            if(participants.Count > 0)
            {
                if(participants.ContainsKey(UserId))
                {
                    message = "이미 참여한 방입니다";
                    Debug.Log(string.Format("이미 참여한 방\nroom_key : {0}", room_key));
                    return TransactionResult.Abort();
                }
                foreach (var pair in participants)
                {
                    if (!(pair.Value is Dictionary<string, object>))
                    {
                        Debug.Log(string.Format("잘못된 방 형식입니다.!\nroom_key : {0}", room_key));
                        message = "잘못된 접근입니다!";
                        return TransactionResult.Abort();
                    }
                    var userinfo = pair.Value as Dictionary<string, object>;
                    if (!userinfo.ContainsKey("team"))
                    {
                        Debug.Log(string.Format("팀 여부가 없음!\nroom_key : {0}, userid : {1}", room_key, pair.Key));
                        message = "잘못된 접근입니다!";
                        return TransactionResult.Abort();
                    }
                    if (userinfo["team"].Equals("red"))
                    {
                        redCount++;
                    }
                    else if (userinfo["team"].Equals("blue"))
                    {
                        blueCount++;
                    }
                    else
                    {
                        Debug.Log(string.Format("알수없는 팀입니다.\nroom_key : {0}, userid : {1}, team : {2}", room_key, pair.Key, userinfo["team"]));
                        return TransactionResult.Abort();
                    }
                    if (!userinfo.ContainsKey("is_master"))
                    {
                        Debug.Log(string.Format("방장 여부가 없음!\nroom_key : {0}, userid : {1}", room_key, pair.Key));
                        message = "잘못된 접근입니다!";
                        return TransactionResult.Abort();
                    }
                    if (userinfo["is_master"].Equals(true))
                    {
                        is_master = false;
                    }
                }
            }
            string team = "red";
            if (redCount == 3 && blueCount == 3)
            {
                message = "방 인원이 꽉 찼습니다!";
                return TransactionResult.Abort();
            }
            else if(redCount > blueCount)
            {
                team = "blue";
            }
            participants.Add(UserId, new Dictionary<string, object>()
                {
                    { "user", this.user.ToDictionary() },
                    { "is_master", is_master },
                    { "team", team }
                }
            );
            mutableData.Value = roomInfo;
            return TransactionResult.Success(mutableData);
        });
        if (message.Equals("성공"))
            this.room_key = room_key;
        return message;
    }

    public async void DestroyRoom()
    {
        await reference.Child("Room").Child(room_key).RunTransaction(mutableData =>
        {
            mutableData.Value = null;
            return TransactionResult.Success(mutableData);
        });
    }

    public async Task<string> ExitRoom()
    {
        string message = "성공";
        var room_ref = reference.Child("Room").Child(room_key);
        await room_ref.RunTransaction(mutableData =>
        {
            var roomInfo = mutableData.Value as Dictionary<string, object>;
            var participants = roomInfo["users"] as Dictionary<string, object>;

            if(participants.ContainsKey(UserId))
            {
                var userinfo = participants[UserId] as Dictionary<string, object>;
                if(!userinfo.ContainsKey("is_master"))
                {
                    Debug.Log(string.Format("방장 유무가 없습니다.\nroom_key : {0}, userid {1}", room_key, UserId));
                    message = "잘못된 접근입니다!";
                    return TransactionResult.Abort();
                }
                if(userinfo["is_master"].Equals(true))
                {
                    if(participants.Count > 1)
                    {
                        // 내가 방장인데 나 말고 다른 사람이 있으면 방장 넘김
                        var next_master = participants.Where(pair => pair.Key != UserId).Select(pair => pair.Key).ToList()[0];
                        var next_master_info = participants[next_master] as Dictionary<string, object>;
                        next_master_info["is_master"] = true;
                    }
                    else
                    {
                        //나 혼자일떈

                    }
                }
            }
            else
            {
                Debug.Log(string.Format("이미 나갔습니다.\nroom_key : {0}", room_key));
                message = "이미 나갔습니다!";
                return TransactionResult.Abort();
            }
            participants.Remove(UserId);
            if (participants.Count == 0)
                roomInfo = null;
            mutableData.Value = roomInfo;
            return TransactionResult.Success(mutableData);
        });
        if (message.Equals("성공"))
        {
            room_key = "";
            room_ref.ValueChanged -= RoomInfoChanged;
        }
        return message;
    }

    public void OnClickMakeRoomBtn()
    {
        MakeRoom(room.text);
        SceneManager.LoadScene(1);
    }

    public void OnClickQuitBtn()
    {
        Debug.Log("나가기");
    }

    public async void OnClickStartBtn()
    {
        if (id.text != "" && name.text!="")
        {
            Action<bool> action = code =>
            {
                auth.CreateUserWithEmailAndPasswordAsync(id.text, "123456").ContinueWith(task => {
                    if (task.IsCanceled)
                    {
                        Debug.Log("CreateUserWithEmailAndPasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.Log("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                        
                        return;
                    }

                    // Firebase user has been created.
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                        newUser.DisplayName, newUser.UserId);
                });
            };
            CreateAccount(id.text, "123456", action);
            user = new User(name.text);
            var message = await SignInWithEmail(id.text, "123456");
            if (message)
            {
                RoomUI.SetActive(true);
                GameStartUI.SetActive(false);
                ReadRoomList();
            }
        }
    }

    private void OnCommandRecieved(object sender, ChildChangedEventArgs e)
    {
        var command = e.Snapshot.Value as Dictionary<string, object>;
        // 방법이 여러가지가 있는데 value 를 직접 뽑아오면 Dictionary<string, object> 형태로 불러와지고
        string command_name = e.Snapshot.Child("Watting").Child("").Value as string;
        // DataSnapshot 에서 뽑아오는 방법도 있음
        Vector2 position = new Vector2(Convert.ToInt32(e.Snapshot.Child("X").Value), Convert.ToInt32(e.Snapshot.Child("y").Value));
    }
}

public class Room
{
    public string roomname;
    public List<string> users;

    private static Room instance = null;
    public static Room Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public Room()
    {
    }

    public Room(string roomname, List<string> users)
    {
        this.roomname = roomname;
        this.users = users;
    }

    public void SetUser(User user)
    {
        this.users.Add(user.username);
    }

    public void OutUser(User user)
    {
        this.users.Remove(user.username);
    }
}

public class ParticipantInfo {
    public User userInfo;
    public bool isMaster;
    public string team;

    public static ParticipantInfo FromDictionary(Dictionary<string, object> dic)
    {
        return new ParticipantInfo
        {
            userInfo = User.FromDictionary(dic["user"] as Dictionary<string, object>),
            isMaster = Convert.ToBoolean(dic["is_master"]),
            team = dic["team"] as string
        };
    }
}

public class User { 
    public string username;

    public User()
    {
    }

    public User(string username)
    {
        this.username = username;
    }

    public IDictionary ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            { "username", username }
        };
    }

    public static User FromDictionary(Dictionary<string ,object> dic)
    {
        return new User()
        {
            username = dic["username"] as string
        };
    }
}