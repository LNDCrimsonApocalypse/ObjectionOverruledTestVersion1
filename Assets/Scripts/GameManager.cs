using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;

    private bool hasTransitionStarted = false; // To track if the transition has started

    private void Start()
    {
        // Initially hide the starting transition
        //_startingSceneTransition.SetActive(false);
        StartSceneSequence();
    }

    // Method to start the starting scene transition
    public void StartSceneSequence()
    {
        if (hasTransitionStarted) return; // Prevent the sequence from starting again if it's already been triggered

        hasTransitionStarted = true; // Mark the transition as started

        // Trigger the start scene transition
        _startingSceneTransition.SetActive(true);

        // Use CoroutineRunner to start the coroutine
        CoroutineRunner.Instance.StartManagedCoroutine(HandleStartingTransition());
    }

    // Coroutine to handle the starting transition
    private IEnumerator HandleStartingTransition()
    {
        // Wait for the start transition to finish (adjust time to match your animation or transition duration)
        yield return new WaitForSeconds(7f); // Adjust this to match the duration of the start transition

        // Hide the start transition after it finishes
        _startingSceneTransition.SetActive(false);
    }
}
