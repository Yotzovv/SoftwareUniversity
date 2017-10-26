namespace SimpleMvc.Framework.Attributes.Property
{
    public class NumberRangeAttribute : PropertyAttribute
    {
        private double minValue;
        private double maxValue;

        protected NumberRangeAttribute(double minValue, double maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object parameter)
        {
            return this.minValue <= (double)parameter && this.maxValue >= (double)parameter;
        }
    }
}
