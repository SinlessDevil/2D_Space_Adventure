using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Localization
{
    [RequireComponent(typeof(Text))]
    public class Localize : LocalizBase
    {
        #region Private Fields
        private Text text;
        #endregion

        #region Public Methods
        public override void UpdateLocale()
        {
            if (!text) return;
            if (!System.String.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageStrings.ContainsKey(localizationKey))
                text.text = Locale.CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n'); ;
        }
        #endregion

        #region Private Methods
        protected override void Start()
        {
            text = GetComponent<Text>();
            base.Start();
        }
        #endregion

    }
}
