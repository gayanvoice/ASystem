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
        public int IsSeatSelection { get; set; } //1
        public int IsSkywardsMiles { get; set; } //1
        public int IsUpgrade { get; set; } //1
        public int IsChangeFee { get; set; } //1
        public int IsRefundFee { get; set; } //1
    }
}