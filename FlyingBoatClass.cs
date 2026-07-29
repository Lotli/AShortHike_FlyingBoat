using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Numerics;

namespace Flying_Boat
{
    public class FlyingBoatClass : MelonMod
    {
        Rigidbody boatRb;
        GameObject trailerShade;
        GameObject rightBoatWing;
        GameObject leftBoatWing;
        GameObject tailWing;
        GameObject leftTailWing;
        GameObject rightTailWing;
        float flyingForce = 1000f;

        public override void OnInitializeMelon()
        {
            MelonEvents.OnGUI.Subscribe(DrawMenu, 100);
        }

        private void DrawMenu()
        {
            //GUI.Box(new Rect(10, 10, 150, 40), "Boat Glider\n By Lotli");
            //flyingForce = float.Parse(GUI.TextArea(new Rect(10, 40, 150, 20), "1000"));
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "GameScene")
            {
                // Creating cosmetic wings for the boat
                SpawnWings();
            }
        }

        public override void OnFixedUpdate()
        {
            if (Input.GetKey(KeyCode.F) && boatRb != null)
            {
                boatRb.AddForce(Vector3.up * flyingForce);
            }
        }

        private void SpawnWings()
        {
            // Right Wing
            boatRb = GameObject.Find("Motorboat").GetComponent<Rigidbody>();
            trailerShade = GameObject.Find("Trailer (1)").transform.GetChild(1).gameObject;
            rightBoatWing = GameObject.Instantiate(trailerShade, boatRb.transform.GetChild(0));
            rightBoatWing.name = "RightBoatWing";
            rightBoatWing.transform.localPosition = new Vector3(6.5f,3.5f,0);
            rightBoatWing.transform.localRotation = Quaternion.Euler(270, 180, 0);
            rightBoatWing.transform.localScale = new Vector3(3, 1.5f, 1);
            rightBoatWing.GetComponent<MeshCollider>().enabled = false;
            rightBoatWing.SetActive(true);

            //Left Wing
            leftBoatWing = GameObject.Instantiate(trailerShade, boatRb.transform.GetChild(0));
            leftBoatWing.name = "LeftBoatWing";
            leftBoatWing.transform.localPosition = new Vector3(-6.5f, 3.5f, 0);
            leftBoatWing.transform.localRotation = Quaternion.Euler(270, 0, 0);
            leftBoatWing.transform.localScale = new Vector3(3, 1.5f, 1);
            leftBoatWing.GetComponent<MeshCollider>().enabled = false;
            leftBoatWing.SetActive(true);

            //Tail Wing
            //Consists of two wings cus the mesh is one sided
            tailWing = new GameObject("TailWing");
            tailWing.transform.SetParent(GameObject.Find("Motor").transform);
            tailWing.transform.localPosition = Vector3.zero;
            rightTailWing = GameObject.Instantiate(trailerShade, tailWing.transform);
            rightTailWing.name = "RightTailWing";
            rightTailWing.transform.localPosition = new Vector3(0.1f, 1, 2);
            rightTailWing.transform.localRotation = Quaternion.Euler(0, 90, 270);
            rightTailWing.transform.localScale = new Vector3(2, 1.5f, 0.1f);
            rightTailWing.GetComponent<MeshCollider>().enabled = false;
            rightTailWing.SetActive(true);
            leftTailWing = GameObject.Instantiate(trailerShade, tailWing.transform);
            leftTailWing.name = "LeftTailWing";
            leftTailWing.transform.localPosition = new Vector3(-0.1f, 1, 2);
            leftTailWing.transform.localRotation = Quaternion.Euler(0, 270, 270);
            leftTailWing.transform.localScale = new Vector3(2, 1.5f, 0.1f);
            leftTailWing.GetComponent<MeshCollider>().enabled = false;
            leftTailWing.SetActive(true);
        }
    }
}
