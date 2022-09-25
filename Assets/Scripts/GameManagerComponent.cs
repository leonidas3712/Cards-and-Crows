using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

struct Message {
    public string messageText;
    public float messageTime;

    public Message(string messageText, float messageTime) {
        this.messageText = messageText;
        this.messageTime = messageTime;
    }
}

public class GameManagerComponent : MonoBehaviour
{
    private static GameManagerComponent _instance;
    public static GameManagerComponent Instance {
        get {
            return _instance;
        }
    }

    public Image messagePanel;
    public TextMeshProUGUI messageText;
    private LinkedList<Message> messageQueue = new LinkedList<Message>();
    private bool isShowingMessage = false;

    public static UnityEvent gameStartedEvent = new UnityEvent();
    public static UnityEvent gameEndedEvent = new UnityEvent();

    public static UnityEvent turnStartedEvent = new UnityEvent();
    public static UnityEvent turnEndedEvent = new UnityEvent();
    
    public static UnityEvent playerTurnStartedEvent = new UnityEvent();
    public static UnityEvent playerTurnEndedEvent = new UnityEvent();
    public static UnityEvent enemyTurnStartedEvent = new UnityEvent();
    public static UnityEvent enemyTurnEndedEvent = new UnityEvent();

    public static UnityEvent battleStartedEvent = new UnityEvent();
    public static UnityEvent battleEndedEvent = new UnityEvent();

    private void InitializeInnerEvents() {
        playerTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        enemyTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        playerTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
        enemyTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
    }

    void Awake() {
        _instance = this;
        InitializeInnerEvents();
        playerTurnStartedEvent.AddListener(
            () => {
                QueueMessage("Your turn!", 1f);
            }
        );
    }

    public static bool IsGameEnd() { 
        return (
            !HeroComponent.playerHeroInstance.IsAlive()
            || !HeroComponent.enemyHeroInstance.IsAlive()
        );
    }

    // Start is called before the first frame update    
    void Start()
    {
        gameStartedEvent.Invoke();
    }

    /** NEVER CALL THIS METHOD! CALL QUEUE MESSAGE INSTEAD! **/
    private void ShowMessage(Message message) {
        /** NEVER CALL THIS METHOD! CALL QUEUE MESSAGE INSTEAD! **/
        isShowingMessage = true;
        messageText.text = message.messageText;
        
        Sequence messageSequence = DOTween.Sequence();
        messageSequence.AppendCallback(
            () => {
                Debug.Log("Showing message!");
                messagePanel.gameObject.SetActive(true);
            }
        );
        messageSequence.Append(messagePanel.DOFade(1, 0.5f));
        messageSequence.Join(messageText.DOFade(1, 0.5f));
        messageSequence.AppendInterval(message.messageTime);
        messageSequence.Append(messagePanel.DOFade(0, 0.5f));
        messageSequence.Join(messageText.DOFade(0, 0.5f));
        messageSequence.OnKill(
            () => {
                Debug.Log("Message ended!");
                messagePanel.gameObject.SetActive(false);
                isShowingMessage = false;

                // Show next message
                if (messageQueue.Count > 0) {
                    Message nextMsg = messageQueue.First.Value;
                    messageQueue.RemoveFirst();
                    ShowMessage(nextMsg);
                }
            }
        );
    }

    public void QueueMessage(string messageText, float messageTime) {
        Debug.Log("Queuing message");
        Message message = new Message(messageText, messageTime);
        if (isShowingMessage) {
            messageQueue.AddLast(message);
            return;
        }
        ShowMessage(message);
    }
}
