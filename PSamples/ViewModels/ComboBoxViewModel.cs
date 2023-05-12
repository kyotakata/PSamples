namespace PSamples.ViewModels
{
    /// <summary>
    /// ComboBox用のクラス
    /// </summary>
    public sealed class ComboBoxViewModel
    {
        /// <summary>
        /// コンストラクタ(完全コンストラクタパターン)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="displayValue"></param>
        public ComboBoxViewModel(int value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }

        /// <summary>
        /// ComboBoxのSelectedValuePathにBindingされるプロパティ
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// ComboBoxのDisplayMemberPathにBindingされるプロパティ
        /// </summary>
        public string DisplayValue { get; }
    }
}
