using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Models.DTOs;

public class CreateMeasurementDto
{
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
public class GetMeasurementDto
{
    public int Id { get; set; }
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
public class UpdateMeasurementDto
{
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
