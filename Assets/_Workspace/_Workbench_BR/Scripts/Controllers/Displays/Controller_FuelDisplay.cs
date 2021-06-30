using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

namespace LunarLander.UI.Displays
{
    public class Controller_FuelDisplay : MonoBehaviour
    {
        [SerializeField] private Text m_DisplayText;

        [SerializeField] private string m_Prefix = "Fuel: ";

        void OnEnable()
        {
            EventManager.AddEventListener("OnReportRemainingFuel", OnReportRemainingFuel);
        }

        void OnDisable()
        {
            EventManager.RemoveEventListener("OnReportRemainingFuel", OnReportRemainingFuel);
        }

        private void OnReportRemainingFuel(object sender, object eventargs)
        {
            float agl = (float) eventargs;
            //Debug.Log($"AGL : {agl} m");
            m_DisplayText.text = $"{m_Prefix} {agl:000.0}";
        }
    }
}