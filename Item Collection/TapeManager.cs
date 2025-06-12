namespace TelemetryManagerExamples
{
    using USCG.Core.Telemetry;

using UnityEngine;

public class TapeManager : MonoBehaviour{
    public GameObject CursorHover; // The hover cursor that should show when the player is looking at the door
    public TapeCounter tapeCounter; // Reference to the TapeCounter script
    private bool inBox;
    private void OnMouseOver()
    {
        if (PlayerCasting.DistanceFromTarget < 4){
            checkCollect();
        }
    }

    void Update(){
        if (inBox){
            checkCollect();
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            inBox = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            inBox = false;
        }
    } 
    private void checkCollect(){
        if (Input.GetKeyDown(KeyCode.E)){
            tapeCounter.CollectTape(transform.position);
            transform.parent.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q) && GameObjectManager.isTesting){
            tapeCounter.CollectTape(transform.position);
        }
    } 
}
}