using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Mob : MonoBehaviour
{
    private AudioSource theAudio;
    [SerializeField] private AudioClip[] Walking;
    [SerializeField] private AudioClip[] Running;
    [SerializeField] private AudioClip[] Slowing;

    private void Start()
    {
        if (GameObject.Find("IngameScreen") != null)
            transform.parent = GameObject.Find("IngameScreen").transform;
        theAudio = GetComponent<AudioSource>();
    }

    public float Range;
    public float velocity;
    float Time_PlaySoundMoving = 0;
    Vector2 PlayerPos;
    public float Rvelocity;
    private void Awake()
    {
        Rvelocity = velocity;
    }

    void Update()
    {
        Time_PlaySoundMoving += Time.deltaTime;
        PlayerPos = (Vector2)GameObject.Find("Player").transform.position;
        if (Distance() > Range)
        {
            transform.position =
            Vector2.MoveTowards(transform.position,
                                PlayerPos,
                                velocity * Time.deltaTime);

            if (Time_PlaySoundMoving >= 2) {
                if (Rvelocity == velocity)
                {
                    AudioPlay_Walking();
                }
                else if (Rvelocity > velocity)
                {
                    AudioPlay_Slowing();
                }
                else if (Rvelocity < velocity)
                {
                    AudioPlay_Running();
                }
                Time_PlaySoundMoving = 0;
            }
        }
        Rotate();
    }
    public float Distance()
    {
        float X = transform.position.x - PlayerPos.x;
        float Y = transform.position.y - PlayerPos.y;
        return Mathf.Sqrt(X * X + Y * Y);
    }

    void Rotate()
    {
        Vector2 direction;
        direction = PlayerPos - (Vector2)transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(0, 90, -90);
    }
    void AudioPlay_Walking()
    {
        int _temp = Random.Range(0, 5);

        theAudio.clip = Walking[_temp];
        theAudio.Play();
    }
    void AudioPlay_Running()
    {
        int _temp = Random.Range(0, 5);

        theAudio.clip = Running[_temp];
        theAudio.Play();
    }
    void AudioPlay_Slowing()
    {
        int _temp = Random.Range(0, 5);

        theAudio.clip = Slowing[_temp];
        theAudio.Play();
    }
}
