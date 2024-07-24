using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class WhisperChatGPTCommunication : MonoBehaviour
{
    // Statik bir değişken, sınıfın örneğine referans verecek
    private static WhisperChatGPTCommunication _instance;
    [SerializeField] ChatGPT chatGPT;
    // Instance'a erişmek için public bir property
    public static WhisperChatGPTCommunication Instance
    {
        get
        {
            // Eğer henüz bir instance yoksa, sahnede arayalım
            if (_instance == null)
            {
                _instance = FindObjectOfType<WhisperChatGPTCommunication>();

                // Eğer sahnede de yoksa, hata mesajı verelim
                if (_instance == null)
                {
                    Debug.LogError("An instance of WhisperChatGPT is needed in the scene, but there is none.");
                }
            }
            return _instance;
        }
    }

    // Awake, GameObject oluşturulmadan hemen önce çağrılır
    private void Awake()
    {
        // Eğer _instance zaten mevcutsa ve bu değilse, bu nesneyi yok et
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Instance olarak bu nesneyi ayarlayın ve yıkılmamasını sağlayın
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendMessageGPT(string userMessage)
    {
        //chatGPT.SendReplyGPT(userMessage);
    }
}