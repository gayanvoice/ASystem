namespace ASystem.Models.Context
{
    public class ClassContextModel
    {
        public int ClassId { get; set; } //11
        public int AirplaneId { get; set; } //11
        public string Name { get; set; } //45
        public string SubClass { get; set; } //45
        public int NoOfSeats { get; set; } //11
        public int BaggageSize { get; set; } //11
        public int CabinBaggageSize { get; set; } //11
        public string IsSeatSelection { get; set; } //20
        public string IsSkywardsMiles { get; set; } //20
        public string IsUpgrade { get; set; } //20
        public string IsChangeFee { get; set; } //20
        public string IsRefundFee { get; set; } //20
    }
}