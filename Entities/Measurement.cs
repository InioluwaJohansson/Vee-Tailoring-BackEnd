using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Measurement: AuditableEntity
    {
        public string Head { get; set; } = "0.00";
        public string NeckSize { get; set; } = "0.00";
        public string ShoulderWidth { get; set; } = "0.00";
        public string BurstGirth { get; set; } = "0.00";
        public string ArmLength { get; set; } = "0.00";
        public string ArmSize { get; set; } = "0.00";
        public string WristCircumfrence { get; set; } = "0.00";
        public string AnkleSize { get; set; } = "0.00";
        public string HipSize { get; set; } = "0.00";
        public string LegLength { get; set; } = "0.00";
        public string WaistSize { get; set; } = "0.00";
        public string BodyHeight { get; set; } = "0.00";

        //Women
        public string FrontWaist { get; set; } = "0.00";
        public string BackWaist { get; set; } = "0.00";
        public string HighHips { get; set; } = "0.00";
        public string ThirdQuarterLegLength { get; set; } = "0.00";

    }
}
