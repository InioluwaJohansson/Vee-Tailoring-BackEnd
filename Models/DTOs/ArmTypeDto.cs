namespace Vee_Tailoring.Models.DTOs;

public class CreateArmTypeDto
{
    public string ArmLength { get; set; }
}
public class GetArmTypeDto
{
    public int Id { get; set; }
    public string ArmLength { get; set; }
}
public class UpdateArmTypeDto
{
    public string ArmLength { get; set; }
}
public class ArmTypeResponseModel : BaseResponse
{
    public GetArmTypeDto Data { get; set; }
}
public class ArmTypesResponseModel : BaseResponse
{
    public ICollection<GetArmTypeDto> Data { get; set; } = new HashSet<GetArmTypeDto>();
}
