using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;

namespace Flying_Boat
{
    public class FlyingBoatClass : MelonMod
    {
        Rigidbody boatRb;
        GameObject trailerShade;
        GameObject rightBoatWing;
        GameObject leftBoatWing;
        float flyingForce = 1000f;

        public override void OnInitializeMelon()
        {
            MelonEvents.OnGUI.Subscribe(DrawMenu, 100);
        }

        private void DrawMenu()
        {
            GUI.Box(new Rect(10, 10, 150, 40), "Boat Glider\nᴮʸ ᴸᴼᵀᴸᴵ");
            //flyingForce = float.Parse(GUI.TextArea(new Rect(10, 40, 150, 20), "1000"));
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "GameScene")
            {
                boatRb = GameObject.Find("Motorboat").GetComponent<Rigidbody>();
                trailerShade = GameObject.Find("Trailer (1)").transform.GetChild(1).gameObject;
                rightBoatWing = GameObject.Instantiate(trailerShade, boatRb.transform.GetChild(0));
                rightBoatWing.name = "RightBoatWing";
                rightBoatWing.transform.localPosition = new Vector3(6.5f,3.5f,0);
                rightBoatWing.transform.localRotation = Quaternion.Euler(270, 180, 0);
                rightBoatWing.transform.localScale = new Vector3(3, 1.5f, 1);
                rightBoatWing.SetActive(true);
                leftBoatWing = GameObject.Instantiate(trailerShade, boatRb.transform.GetChild(0));
                leftBoatWing.name = "LeftBoatWing";
                leftBoatWing.transform.localPosition = new Vector3(-6.5f, 3.5f, 0);
                leftBoatWing.transform.localRotation = Quaternion.Euler(270, 0, 0);
                leftBoatWing.transform.localScale = new Vector3(3, 1.5f, 1);
                leftBoatWing.SetActive(true);
            }
        }

        public override void OnFixedUpdate()
        {
            if (Input.GetKey(KeyCode.F) && boatRb != null)
            {
                boatRb.AddForce(Vector3.up * flyingForce);
            }
        }
    }
}
