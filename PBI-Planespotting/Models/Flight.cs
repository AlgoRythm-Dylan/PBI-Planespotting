namespace PBI_Planespotting.Models
{
    public class Flight
    {
        public bool IsDeparting { get; set; }
        public string? City { get; set; }

        #region Calculated Properties
        public bool IsArriving
        {
            get
            {
                return !IsDeparting;
            }
            set
            {
                IsDeparting = !value;
            }
        }
        #endregion
    }
}
