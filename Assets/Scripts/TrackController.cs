using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public GameObject[] Tracks;
    private GameObject _currentTrack;
    private GameObject _lastTrack;
    private int _currentTrackValue = 0;
    private int _currentLastTrackValue = 9;
    private static TrackController _instance;

    public static TrackController instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        _currentTrack = Tracks[0];
        _lastTrack = Tracks[9];

        //Debug.Log(_currentTrack);
        //Debug.Log(_lastTrack);
        //Debug.Log(_currentTrackValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTrack() 
    {
        //Debug.Log("mudou");
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 500 * 4);
        //currentTrack.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 500 * 4);
        // 500
        _currentTrack.transform.position = new Vector3(_lastTrack.transform.position.x, _lastTrack.transform.position.y, _lastTrack.transform.position.z + 50);

        _lastTrack = _currentTrack;


        if (_currentTrack == Tracks[9])
        {
            _currentTrack = Tracks[0];
            _currentTrackValue = 0;
            //Debug.Log("current value: " + _currentTrackValue);
        }
        else
        {
            _currentTrackValue++;
            _currentTrack = Tracks[_currentTrackValue];
            //Debug.Log("aumentou");
            //Debug.Log("current value: " + _currentTrackValue);
        }

        //Debug.Log("Current track :" + _currentTrack);
        //Debug.Log("Last Track :" + _lastTrack);

    }

    public void ClearAllTracks()
    {
        foreach (var __track in Tracks)
        {
            __track.GetComponent<Track>().ClearTrack();
        }

    }

}
