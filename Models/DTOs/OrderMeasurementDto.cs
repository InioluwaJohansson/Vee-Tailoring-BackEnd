namespace Vee_Tailoring.Models.DTOs;

public class CreateOrderMeasurementDto
{
    public string OrderId { get; set; }
    public decimal Head { get; set; }
    public decimal NeckSize { get; set; }
    public decimal ShoulderWidth { get; set; }
    public decimal BurstGirth { get; set; }
    public decimal ArmLength { get; set; }
    public decimal ArmSize { get; set; }
    public decimal WristCircumfrence { get; set; }
    public decimal AnkleSize { get; set; }
    public decimal HipSize { get; set; }
    public decimal LegLength { get; set; }
    public decimal WaistSize { get; set; }
    public decimal BodyHeight { get; set; }

    //Women
    public decimal FrontWaist { get; set; }
    public decimal BackWaist { get; set; }
    public decimal HighHips { get; set; }
    public decimal ThirdQuarterLegLength { get; set; }
}
public class GetOrderMeasurementDto
{
    public int Id { get; set; }
    public string OrderId { get; set; }
    public decimal Head { get; set; }
    public decimal NeckSize { get; set; }
    public decimal ShoulderWidth { get; set; }
    public decimal BurstGirth { get; set; }
    public decimal ArmLength { get; set; }
    public decimal ArmSize { get; set; }
    public decimal WristCircumfrence { get; set; }
    public decimal AnkleSize { get; set; }
    public decimal HipSize { get; set; }
    public decimal LegLength { get; set; }
    public decimal WaistSize { get; set; }
    public decimal BodyHeight { get; set; }

    //Women
    public decimal FrontWaist { get; set; }
    public decimal BackWaist { get; set; }
    public decimal HighHips { get; set; }
    public decimal ThirdQuarterLegLength { get; set; }
}
public class UpdateOrderMeasurementDto
{
    public string OrderId { get; set; }
    public decimal Head { get; set; }
    public decimal NeckSize { get; set; }
    public decimal ShoulderWidth { get; set; }
    public decimal BurstGirth { get; set; }
    public decimal ArmLength { get; set; }
    public decimal ArmSize { get; set; }
    public decimal WristCircumfrence { get; set; }
    public decimal AnkleSize { get; set; }
    public decimal HipSize { get; set; }
    public decimal LegLength { get; set; }
    public decimal WaistSize { get; set; }
    public decimal BodyHeight { get; set; }

    //Women
    public decimal FrontWaist { get; set; }
    public decimal BackWaist { get; set; }
    public decimal HighHips { get; set; }
    public decimal ThirdQuarterLegLength { get; set; }
}
