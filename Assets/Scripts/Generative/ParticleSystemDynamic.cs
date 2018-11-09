using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDynamic : MonoBehaviour {
    public enum ParticleMode
    {
        cone = 0,
        donut,
        line,
        grow,
        shrink,
        spin 
    }
    ParticleMode myMode;
    ParticleSystem PS;
    ParticleSystem.ShapeModule myShape;
    ParticleSystem.ColorOverLifetimeModule myColor;
    ParticleSystem.SizeOverLifetimeModule mySize;
    ParticleSystem.RotationOverLifetimeModule myRot;
    Gradient grad;
    Vector3 clickPos;
    Vector3 clickPosWorldPos;
    [SerializeField] Camera cam; 
	void Start () {
        PS = this.GetComponent<ParticleSystem>();
        myShape = PS.shape;
        myColor = PS.colorOverLifetime;
        grad = new Gradient();
        mySize = PS.sizeOverLifetime;
        myRot = PS.rotationOverLifetime;
	}
	
	void Update () {
        if(Input.GetMouseButton(0)){
            clickPos = Input.mousePosition;
            clickPosWorldPos = cam.ScreenToWorldPoint(new Vector3(clickPos.x, clickPos.y, cam.nearClipPlane));
            this.transform.position = clickPosWorldPos;
            Debug.Log("clickPosWoldPos: " + clickPosWorldPos);
            myMode = HorizCheck(clickPosWorldPos.x);
            Debug.Log("myMode: " + myMode);
            PS.Emit(1);
        }

        switch (myMode){
            case ParticleMode.cone:
                myShape.enabled = true;
                myShape.shapeType = ParticleSystemShapeType.Cone;
                myColor.enabled = false;
                break;
            case ParticleMode.donut:
                myShape.enabled = true;
                myShape.shapeType = ParticleSystemShapeType.Donut;
                myColor.enabled = true;
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, 
                             new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                myColor.color = grad;
                break;
            case ParticleMode.line:
                myShape.enabled = false;
                myColor.enabled = false;
                break;
            case ParticleMode.grow:
                mySize.enabled = true;
                mySize.sizeMultiplier = 10f;
                break;
            case ParticleMode.shrink:
                mySize.enabled = true;
                mySize.size = 0.5f;
                break;
            case ParticleMode.spin:
                myRot.enabled = true;
                myRot.xMultiplier = 10f;
                break;
            default:
                break;
        }
	}

    ParticleMode HorizCheck(float someNum){
        ParticleMode tempMode;
        if(someNum < -.666){
            tempMode = ParticleMode.cone;
        } else if (someNum <-.333 && someNum >= -.666){
            tempMode = ParticleMode.donut;
        }else if(someNum < 0 && someNum >= -.333){
            tempMode = ParticleMode.grow;
        }else if (someNum < .333 && someNum >= 0){
            tempMode = ParticleMode.line;
        }else if ( someNum < .666 && someNum >= .333){
            tempMode = ParticleMode.shrink;
        } else{
            tempMode = ParticleMode.spin;
        }
        return tempMode;
    }

}

