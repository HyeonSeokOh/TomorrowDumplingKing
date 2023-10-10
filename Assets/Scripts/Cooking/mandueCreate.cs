using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mandueCreate : MonoBehaviour
{
    public GameObject dumpling;
    public VRGrap vrGrap;

    private void OnCollisionEnter(Collision other)
    {
        //vrGrap = this.transform.parent.GetComponent<VRGrap>();
        //vrGrap.TakeWeapon(false);

        if (other.gameObject.tag == "manduIn")
        {
            GameObject mt = Instantiate(dumpling);
            mt.tag = "Mandu";
            mt.transform.position = this.transform.position;

            Destroy(this.GetComponentInParent<FixedJoint>());
            Destroy(this.gameObject);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "KmanduIn")
        {
            GameObject mt = Instantiate(dumpling);
            mt.tag = "Kmandu";
            mt.transform.position = this.transform.position;

            Destroy(this.GetComponentInParent<FixedJoint>());
            Destroy(this.gameObject);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }
    }

}
